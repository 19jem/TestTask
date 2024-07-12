namespace TestClient
{
    partial class SpecialRequestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            getIPBtn = new Button();
            getLastReqBtn = new Button();
            specialRequestTxtBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // getIPBtn
            // 
            getIPBtn.Location = new Point(511, 103);
            getIPBtn.Name = "getIPBtn";
            getIPBtn.Size = new Size(261, 53);
            getIPBtn.TabIndex = 0;
            getIPBtn.Text = "Find last request\r\n(Enter IP)";
            getIPBtn.UseVisualStyleBackColor = true;
            getIPBtn.Click += getIPBtn_Click;
            // 
            // getLastReqBtn
            // 
            getLastReqBtn.Location = new Point(512, 170);
            getLastReqBtn.Name = "getLastReqBtn";
            getLastReqBtn.Size = new Size(260, 52);
            getLastReqBtn.TabIndex = 1;
            getLastReqBtn.Text = "Find IPs\r\n(Enter machine name)\r\n";
            getLastReqBtn.UseVisualStyleBackColor = true;
            getLastReqBtn.Click += getLastReqBtn_Click;
            // 
            // specialRequestTxtBox
            // 
            specialRequestTxtBox.Location = new Point(103, 122);
            specialRequestTxtBox.Multiline = true;
            specialRequestTxtBox.Name = "specialRequestTxtBox";
            specialRequestTxtBox.Size = new Size(354, 95);
            specialRequestTxtBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 86);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 3;
            label1.Text = "Enter text";
            // 
            // SpecialRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(specialRequestTxtBox);
            Controls.Add(getLastReqBtn);
            Controls.Add(getIPBtn);
            Name = "SpecialRequestForm";
            Text = "SpecialRequestForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button getIPBtn;
        private Button getLastReqBtn;
        private TextBox specialRequestTxtBox;
        private Label label1;
    }
}