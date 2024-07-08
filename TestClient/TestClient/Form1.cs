using System.Configuration;
using System.Net.Sockets;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TestClient
{
    public partial class ClientForm : Form
    {
        private bool IsAuthenticated = false;
        private string Username;
        string serverIp = ConfigurationManager.AppSettings["ServerIp"];
        int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        public ClientForm()
        {
            InitializeComponent();
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
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}
