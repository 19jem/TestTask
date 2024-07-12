using System.Configuration;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Timers;

namespace TestClient
{
    public partial class ClientForm : Form
    {
        private bool IsAuthenticated = false;
        private string Username;
        string serverIp;
        int port;
        private System.Timers.Timer connectionCheckTimer;

        public ClientForm()
        {
            InitializeComponent();
            LoadConfiguration();

            // timer for automatical sending saved data on client
            connectionCheckTimer = new System.Timers.Timer(5000);
            connectionCheckTimer.Elapsed += CheckServerConnection;
            connectionCheckTimer.AutoReset = true;
            connectionCheckTimer.Start();

        }
        private void LoadConfiguration()
        {
            serverIp = ConfigurationManager.AppSettings["ServerIp"] ?? "127.0.0.1";
            port = int.Parse(ConfigurationManager.AppSettings["Port"] ?? "8080");
        }

        private void CheckServerConnection(object sender, ElapsedEventArgs e)
        {
            if (IsServerAvailable())
            {
                SendSavedRequests();
            }
        }

        private bool IsServerAvailable()
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(serverIp, port);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string machineName = Environment.MachineName;
            string clientDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string textData = txtBox.Text;

            string requestData = $"{machineName}|{clientDateTime}|{textData}";

            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                {
                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(requestData);
                    writer.Flush();

                    StreamReader reader = new StreamReader(stream);
                    string response = reader.ReadLine();
                    MessageBox.Show("Information sent.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                SaveToJson(machineName, clientDateTime, textData);
            }
        }

        private void SaveToJson(string machineName, string clientDateTime, string textData)
        {
            string jsonFilePath = "failedRequests.json";
            var failedRequests = new List<Dictionary<string, string>>();

            if (File.Exists(jsonFilePath))
            {
                string existingJson = File.ReadAllText(jsonFilePath);
                failedRequests = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(existingJson);
            }
            var newRequest = new Dictionary<string, string>
    {
            { "machineName", machineName },
            { "clientDateTime", clientDateTime },
            { "textData", textData }
    };

            failedRequests.Add(newRequest);

            string newJson = JsonConvert.SerializeObject(failedRequests, Formatting.Indented);
            File.WriteAllText(jsonFilePath, newJson);
            MessageBox.Show("Information saved offline.");

        }

        private void SendSavedRequests()
        {
            string jsonFilePath = "failedRequests.json";

            if (File.Exists(jsonFilePath))
            { 
                var failedRequests = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(jsonFilePath));
                var successfullySentRequests = new List<Dictionary<string, string>>();
               try
                {
                    foreach (var request in failedRequests)
                    {
                        try
                        {
                            using (TcpClient client = new TcpClient(serverIp, port))
                            {
                                NetworkStream stream = client.GetStream();
                                StreamWriter writer = new StreamWriter(stream);
                                StreamReader reader = new StreamReader(stream);
                                string requestData = $"{request["machineName"]}|{request["clientDateTime"]}|{request["textData"]}";
                                writer.WriteLine(requestData);
                                writer.Flush();

                                string response = reader.ReadLine();

                                if (response == "Received")
                                {
                                    successfullySentRequests.Add(request);
                                }
                                writer.Close();
                                reader.Close();
                                stream.Close(); 
                                client.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error sending saved requests: " + ex.Message);
                        }

                    }
                    failedRequests.RemoveAll(r => successfullySentRequests.Contains(r));

                    if (failedRequests.Count > 0)
                    {
                        string newJson = JsonConvert.SerializeObject(failedRequests, Formatting.Indented);
                        File.WriteAllText(jsonFilePath, newJson);
                    }
                    else
                    {
                        File.Delete(jsonFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending saved requests: " + ex.Message);
                }
            }
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(IsAuthenticated, Username);
            loginForm.ShowDialog();

            if (loginForm.IsAuthenticated)
            {
                IsAuthenticated = true;
                Username = loginForm.Username;
                loginBtn.Text = "Login: " + Username;
            }
        }

        private void specialReqBtn_Click(object sender, EventArgs e)
        {
            if (!IsAuthenticated)
            {
                MessageBox.Show("Please log in to send requests.");
                return;
            }

            SpecialRequestForm specialRequestsForm = new SpecialRequestForm(serverIp, port);
            specialRequestsForm.ShowDialog();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
            SettingsForm settingsForm = new SettingsForm(serverIp, port);
            settingsForm.ConfigUpdated += OnConfigUpdated;
            settingsForm.ShowDialog();
        }
        private void OnConfigUpdated()
        {
            LoadConfiguration(); 
        }
    }
}
