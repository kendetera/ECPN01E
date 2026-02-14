namespace Elective
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            panel1 = new Panel();
            cancelBtn = new Button();
            loginBtn = new Button();
            pictureBox1 = new PictureBox();
            passwordTxtBox = new TextBox();
            usernameTxtBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(loginBtn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(passwordTxtBox);
            panel1.Controls.Add(usernameTxtBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(789, 727);
            panel1.TabIndex = 28;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.Location = new Point(424, 479);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(97, 46);
            cancelBtn.TabIndex = 41;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            loginBtn.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginBtn.Location = new Point(321, 479);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(97, 46);
            loginBtn.TabIndex = 40;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(332, 204);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 147);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(301, 436);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.PasswordChar = '*';
            passwordTxtBox.Size = new Size(248, 23);
            passwordTxtBox.TabIndex = 38;
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.Location = new Point(301, 394);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(248, 23);
            usernameTxtBox.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(203, 434);
            label2.Name = "label2";
            label2.Size = new Size(86, 21);
            label2.TabIndex = 36;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(203, 392);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 35;
            label1.Text = "Username:";
            // 
            // Login_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 727);
            Controls.Add(panel1);
            Name = "Login_Form";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button cancelBtn;
        private Button loginBtn;
        private PictureBox pictureBox1;
        private TextBox passwordTxtBox;
        private TextBox usernameTxtBox;
        private Label label2;
        private Label label1;
    }
}
