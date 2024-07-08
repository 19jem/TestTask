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
            newIpTxtBox = new TextBox();
            newPortTxtBox = new TextBox();
            updateBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // newIpTxtBox
            // 
            newIpTxtBox.Location = new Point(84, 118);
            newIpTxtBox.Name = "newIpTxtBox";
            newIpTxtBox.Size = new Size(299, 27);
            newIpTxtBox.TabIndex = 0;
            // 
            // newPortTxtBox
            // 
            newPortTxtBox.Location = new Point(82, 198);
            newPortTxtBox.Name = "newPortTxtBox";
            newPortTxtBox.Size = new Size(299, 27);
            newPortTxtBox.TabIndex = 1;
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
            Controls.Add(newPortTxtBox);
            Controls.Add(newIpTxtBox);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox newIpTxtBox;
        private TextBox newPortTxtBox;
        private Button updateBtn;
        private Label label1;
        private Label label2;
    }
}