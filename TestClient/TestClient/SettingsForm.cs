using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class SettingsForm : Form
    {
        public event Action ConfigUpdated;

        private string serverIp;
        private int port;
        public SettingsForm(string serverIp, int port)
        {
            InitializeComponent();
            this.serverIp = serverIp;
            this.port = port;

            LoadConfigData();
        }

        private void LoadConfigData()
        {
            ipTxtBox.Text = serverIp;
            portTxtBox.Text = port.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string newIp = ipTxtBox.Text;
            string newPort = portTxtBox.Text;

            UpdateConfig(newIp, newPort);
            ConfigUpdated?.Invoke();
            this.Close();
        }
        //updating config file in client for connect
        private void UpdateConfig(string serverIp, string port)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ServerIp"].Value = serverIp;
            config.AppSettings.Settings["Port"].Value = port;
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Configuration saved successfully");
        }
    }
}
