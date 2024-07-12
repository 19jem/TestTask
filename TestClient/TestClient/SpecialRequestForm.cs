using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class SpecialRequestForm : Form
    {
        private string serverIp;
        private int port;

        public SpecialRequestForm(string serverIp, int port)
        {
            InitializeComponent();
            this.serverIp = serverIp;
            this.port = port;
        }

        private void getIPBtn_Click(object sender, EventArgs e)
        {
            string ipAddress = specialRequestTxtBox.Text;
            string request = $"SPECIAL_REQUEST:IPAddress:{ipAddress}";
            Console.WriteLine("Sending request: " + request);

            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                {
                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);
                    StreamReader reader = new StreamReader(stream);

                    writer.WriteLine(request);
                    writer.Flush();
                    Console.WriteLine("Request sent");

                    string response = reader.ReadLine();
                    Console.WriteLine("Received response: " + response);
                    MessageBox.Show("Last Request Time: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void getLastReqBtn_Click(object sender, EventArgs e)
        {
            string machineName = specialRequestTxtBox.Text;
            string request = $"SPECIAL_REQUEST:MachineName:{machineName}";

            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                {
                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);
                    StreamReader reader = new StreamReader(stream);

                    writer.WriteLine(request);
                    writer.Flush();

                    string response = reader.ReadLine();
                    MessageBox.Show("IP Addresses: " + response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SendSpecialRequest(string request)
        {
            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                {
                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(request);
                    writer.Flush();

                    StreamReader reader = new StreamReader(stream);
                    string response = reader.ReadLine();

                    MessageBox.Show(response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
