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
            string ip = specialRequestTxtBox.Text;
            SendSpecialRequest($"GET_IPS|{ip}");
        }

        private void getLastReqBtn_Click(object sender, EventArgs e)
        {
            string lastReq = specialRequestTxtBox.Text;
            SendSpecialRequest($"GET_LAST_REQUEST|{lastReq}");
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
