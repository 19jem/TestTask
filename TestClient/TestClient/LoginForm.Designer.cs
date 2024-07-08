namespace TestClient
{
    partial class LoginForm
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
            userTxtBox = new TextBox();
            passwordTxtBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            loginEnterBtn = new Button();
            SuspendLayout();
            // 
            // userTxtBox
            // 
            userTxtBox.Location = new Point(222, 100);
            userTxtBox.Name = "userTxtBox";
            userTxtBox.Size = new Size(330, 27);
            userTxtBox.TabIndex = 0;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(220, 170);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(330, 27);
            passwordTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(345, 41);
            label1.Name = "label1";
            label1.Size = new Size(102, 38);
            label1.TabIndex = 2;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 71);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 3;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(215, 142);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // loginEnterBtn
            // 
            loginEnterBtn.Location = new Point(309, 240);
            loginEnterBtn.Name = "loginEnterBtn";
            loginEnterBtn.Size = new Size(170, 52);
            loginEnterBtn.TabIndex = 5;
            loginEnterBtn.Text = "Enter";
            loginEnterBtn.UseVisualStyleBackColor = true;
            loginEnterBtn.Click += loginEnterBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginEnterBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTxtBox);
            Controls.Add(userTxtBox);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userTxtBox;
        private TextBox passwordTxtBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button loginEnterBtn;
    }
}