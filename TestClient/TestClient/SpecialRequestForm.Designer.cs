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
            SuspendLayout();
            // 
            // getIPBtn
            // 
            getIPBtn.Location = new Point(514, 123);
            getIPBtn.Name = "getIPBtn";
            getIPBtn.Size = new Size(135, 44);
            getIPBtn.TabIndex = 0;
            getIPBtn.Text = "Get IP";
            getIPBtn.UseVisualStyleBackColor = true;
            getIPBtn.Click += getIPBtn_Click;
            // 
            // getLastReqBtn
            // 
            getLastReqBtn.Location = new Point(513, 176);
            getLastReqBtn.Name = "getLastReqBtn";
            getLastReqBtn.Size = new Size(135, 43);
            getLastReqBtn.TabIndex = 1;
            getLastReqBtn.Text = "Get last request";
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
            // SpecialRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}