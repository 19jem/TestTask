using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using System.Linq;


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

        //starting for server
        protected override void OnStart(string[] args)
        {
            baseFolder = ConfigurationManager.AppSettings["MainPathFolder"];
            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            listener = new TcpListener(IPAddress.Any, port);

            cancellationTokenSource = new CancellationTokenSource();

            listenerTask = Task.Run(() => StartListening(cancellationTokenSource.Token));
        }

        //start listening
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
                StreamWriter writer = new StreamWriter(stream);
                string request = reader.ReadLine();
                Console.WriteLine("Received request: " + request);
                string[] parts = request.Split('|');

                if (request.StartsWith("SPECIAL_REQUEST"))
                {
                    HandleSpecialRequest(request, writer);
                }
                else if (parts.Length < 3)
                {
                    HandleInvalidData(request);
                    writer.WriteLine("InvalidData");
                }
                else 
                {
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

                        SaveToJson(machineName, clientIP, clientDateTime, textData);

                        writer.WriteLine("Received");

                    writer.Flush();

                    reader.Close();
                    writer.Close();
                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        private void HandleInvalidData(string request)
        {
            try
            {
                string[] parts = request.Split('|');
                string machineName = parts[0];
                string invalidDataFolder = Path.Combine(baseFolder, machineName, ".InvalidData");
                string dateFolder = DateTime.Now.ToString("dd_MM_yyyy");
                string timeFile = DateTime.Now.ToString("HH_mm_ss") + ".txt";
                string invalidDataFolderPath = Path.Combine(invalidDataFolder, dateFolder);

                Directory.CreateDirectory(invalidDataFolderPath);

                string filePath = Path.Combine(invalidDataFolderPath, timeFile);
                File.WriteAllText(filePath, $"Invalid data received:\n{request}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving invalid data: " + ex.Message);
            }
        }

        private void HandleSpecialRequest(string request, StreamWriter writer)
        {
            try
            {
                string[] parts = request.Split(':');
                if (parts.Length != 3)
                {
                    writer.WriteLine("Invalid special request format");
                    writer.Flush(); 
                    return;
                }
                string requestType = parts[1];
                string requestData = parts[2];

                if (requestType == "MachineName")
                {
                    string response = GetIPsForMachine(requestData);
                    writer.WriteLine(response);
                    writer.Flush(); 
                }
                else if (requestType == "IPAddress")
                {
                    string response = GetLastRequestTime(requestData);
                    writer.WriteLine(response);
                    writer.Flush(); 
                }
                else
                {
                    writer.WriteLine("Unknown special request type");
                    writer.Flush(); 
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine("Error processing special request: " + ex.Message);
                writer.Flush(); 
            }
        }


        private string GetIPsForMachine(string machineName)
        {
            try
            {
                string jsonFolderPath = Path.Combine(baseFolder, "receivedRequests");
                string jsonFilePath = Path.Combine(jsonFolderPath, "request.json");

                if (!File.Exists(jsonFilePath))
                {
                    return "No data available";
                }

                var allRequests = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(jsonFilePath));

                var ipAddresses = allRequests
                    .Where(r => r["machineName"] == machineName)
                    .Select(r => r["clientIP"])
                    .Distinct()
                    .ToList();

                if (!ipAddresses.Any())
                {
                    return $"No requests found for machine name: {machineName}";
                }

                return string.Join(",", ipAddresses);
            }
            catch (Exception ex)
            {
                return "Error retrieving IPs: " + ex.Message;
            }
        }

        private string GetLastRequestTime(string ipAddress)
        {
            try
            {
                string jsonFolderPath = Path.Combine(baseFolder, "receivedRequests");
                string jsonFilePath = Path.Combine(jsonFolderPath, "request.json");
                var allRequests = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(jsonFilePath));

                if (!File.Exists(jsonFilePath))
                {
                    return "No data available";
                }

                var lastRequest = allRequests
                    .Where(r => r["clientIP"] == ipAddress)
                    .OrderByDescending(r => DateTime.Parse(r["clientDateTime"]))
                    .FirstOrDefault();

                if (lastRequest != null)
                {
                    return lastRequest["clientDateTime"];
                }

                return "No requests found for this IP address";
            }
            catch (Exception ex)
            {
                return "Error getting last request time: " + ex.Message;
            }
        }

        private void SaveToJson(string machineName, string clientIP, DateTime clientDateTime, string textData)
        {

            string jsonFolderPath = Path.Combine(baseFolder, "receivedRequests");
            string jsonFilePath = Path.Combine(jsonFolderPath, "request.json");

            if (!Directory.Exists(jsonFolderPath))
            {
                Directory.CreateDirectory(jsonFolderPath);
            }

            var receivedRequests = new List<Dictionary<string, string>>();

            if (File.Exists(jsonFilePath))
            {
                string existingJson = File.ReadAllText(jsonFilePath);
                receivedRequests = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(existingJson);
            }

            var newRequest = new Dictionary<string, string>
            {
                { "machineName", machineName },
                { "clientIP", clientIP },
                { "clientDateTime", clientDateTime.ToString("yyyy-MM-dd HH:mm:ss") },
                { "textData", textData }
            };

            receivedRequests.Add(newRequest);

            string newJson = JsonConvert.SerializeObject(receivedRequests, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFilePath, newJson);
        }

        protected override void OnStop()
        {
            cancellationTokenSource.Cancel();
            listener.Stop();
            listenerTask.Wait();
        }

    }
   
}
