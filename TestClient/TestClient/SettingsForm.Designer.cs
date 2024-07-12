namespace TestClient
{
    partial class SettingsForm
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
            ipTxtBox = new TextBox();
            portTxtBox = new TextBox();
            updateBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // ipTxtBox
            // 
            ipTxtBox.Location = new Point(84, 118);
            ipTxtBox.Name = "ipTxtBox";
            ipTxtBox.Size = new Size(299, 27);
            ipTxtBox.TabIndex = 0;
            // 
            // portTxtBox
            // 
            portTxtBox.Location = new Point(82, 198);
            portTxtBox.Name = "portTxtBox";
            portTxtBox.Size = new Size(299, 27);
            portTxtBox.TabIndex = 1;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(508, 143);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(156, 60);
            updateBtn.TabIndex = 2;
            updateBtn.Text = "Update settings";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 85);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 3;
            label1.Text = "Enter new server IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 172);
            label2.Name = "label2";
            label2.Size = new Size(152, 20);
            label2.TabIndex = 4;
            label2.Text = "Enter new server port:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(updateBtn);
            Controls.Add(portTxtBox);
            Controls.Add(ipTxtBox);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ipTxtBox;
        private TextBox portTxtBox;
        private Button updateBtn;
        private Label label1;
        private Label label2;
    }
}