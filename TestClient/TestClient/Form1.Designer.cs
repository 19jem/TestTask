namespace TestClient
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sendBtn = new Button();
            txtBox = new TextBox();
            label1 = new Label();
            loginBtn = new Button();
            specialReqBtn = new Button();
            settingsBtn = new Button();
            SuspendLayout();
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(579, 166);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(122, 52);
            sendBtn.TabIndex = 0;
            sendBtn.Text = "Send!";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // txtBox
            // 
            txtBox.Location = new Point(48, 82);
            txtBox.Multiline = true;
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(402, 244);
            txtBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 54);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 2;
            label1.Text = "Enter your text here:";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(45, 385);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(211, 38);
            loginBtn.TabIndex = 3;
            loginBtn.Text = "Login: not authenticated";
            loginBtn.TextAlign = ContentAlignment.MiddleLeft;
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // specialReqBtn
            // 
            specialReqBtn.Location = new Point(581, 242);
            specialReqBtn.Name = "specialReqBtn";
            specialReqBtn.Size = new Size(122, 52);
            specialReqBtn.TabIndex = 4;
            specialReqBtn.Text = "Special request";
            specialReqBtn.UseVisualStyleBackColor = true;
            specialReqBtn.Click += specialReqBtn_Click;
            // 
            // settingsBtn
            // 
            settingsBtn.Location = new Point(693, 382);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(84, 55);
            settingsBtn.TabIndex = 5;
            settingsBtn.Text = "Server settings";
            settingsBtn.UseVisualStyleBackColor = true;
            settingsBtn.Click += settingsBtn_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(settingsBtn);
            Controls.Add(specialReqBtn);
            Controls.Add(loginBtn);
            Controls.Add(label1);
            Controls.Add(txtBox);
            Controls.Add(sendBtn);
            Name = "ClientForm";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendBtn;
        private TextBox txtBox;
        private Label label1;
        private Button loginBtn;
        private Button specialReqBtn;
        private Button settingsBtn;
    }
}
