using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TestClient
{
    public partial class LoginForm : Form
    {
        public bool IsAuthenticated;
        public string Username;
        public LoginForm(bool IsAuthenticated, string Username)
        {
            InitializeComponent();
            this.IsAuthenticated = IsAuthenticated;
            this.Username = Username;
        }

        private void loginEnterBtn_Click(object sender, EventArgs e)
        {
            string username = userTxtBox.Text;
            string password = passwordTxtBox.Text;

            if (username == "admin" && password == "password")
            {
                IsAuthenticated = true;
                Username = username;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
