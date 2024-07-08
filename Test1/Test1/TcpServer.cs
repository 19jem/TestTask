using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;


namespace Test1
{
    public partial class TcpServer : ServiceBase
    {
        private TcpListener listener;
        private string baseFolder;
        private CancellationTokenSource cancellationTokenSource;
        private Task listenerTask;

        public TcpServer() 
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            baseFolder = ConfigurationManager.AppSettings["MainPathFolder"];
            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            listener = new TcpListener(IPAddress.Any, port);

            cancellationTokenSource = new CancellationTokenSource();

            listenerTask = Task.Run(() => StartListening(cancellationTokenSource.Token));
        }

        private void StartListening(CancellationToken cancellationToken)
        {
            listener.Start();
            Console.WriteLine("Start server...");

            while(!cancellationToken.IsCancellationRequested)
            {
                if(listener.Pending())
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Run(() => HandleClient(client, cancellationToken));
                }
            }
        }

        private void HandleClient(TcpClient client, CancellationToken cancellationToken)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                string request = reader.ReadLine();

                string[] parts = request.Split('|');
                string machineName = parts[0];
                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                DateTime clientDateTime = DateTime.Parse(parts[1]);
                string textData = parts[2];

                string dateFolder = clientDateTime.ToString("dd_MM_yyyy");
                string timeFile = clientDateTime.ToString("HH_mm_ss") + ".txt";

                string clientFolder = Path.Combine(baseFolder, machineName);
                string dateFolderPath = Path.Combine(clientFolder, dateFolder);
                string filePath = Path.Combine(dateFolderPath, timeFile);

                Directory.CreateDirectory(dateFolderPath);

                File.WriteAllText(filePath, $"1.{machineName}\n2. {clientIP}\n3. {clientDateTime}\n4. {textData}");

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        protected override void OnStop()
        {
            cancellationTokenSource.Cancel();
            listener.Stop();
            listenerTask.Wait();
        }

    }
   
}
