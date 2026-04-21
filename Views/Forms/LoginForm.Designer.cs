// File: Views/Forms/LoginForm.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Control
        private Panel pnlBackground;
        private Panel pnlLoginBox;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlLoginBox = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();

            this.pnlBackground.SuspendLayout();
            this.pnlLoginBox.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.FromArgb(240, 242, 245); // Màu nền xám nhạt (Light theme)
            this.pnlBackground.Controls.Add(this.pnlLoginBox);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(800, 450);

            // 
            // pnlLoginBox
            // 
            this.pnlLoginBox.BackColor = System.Drawing.Color.White;
            this.pnlLoginBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoginBox.Controls.Add(this.btnLogin);
            this.pnlLoginBox.Controls.Add(this.txtPassword);
            this.pnlLoginBox.Controls.Add(this.lblPassword);
            this.pnlLoginBox.Controls.Add(this.txtUsername);
            this.pnlLoginBox.Controls.Add(this.lblUsername);
            this.pnlLoginBox.Controls.Add(this.lblSubtitle);
            this.pnlLoginBox.Controls.Add(this.lblTitle);
            this.pnlLoginBox.Location = new System.Drawing.Point(225, 60); // Căn giữa giả định
            this.pnlLoginBox.Name = "pnlLoginBox";
            this.pnlLoginBox.Size = new System.Drawing.Size(350, 330);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "MIEDU";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblSubtitle.Location = new System.Drawing.Point(60, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Hệ thống Quản lý Giảng viên";

            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUsername.Location = new System.Drawing.Point(30, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Text = "Tên đăng nhập";

            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(30, 125);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(290, 27);

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPassword.Location = new System.Drawing.Point(30, 165);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Text = "Mật khẩu";

            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(30, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(290, 27);

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(13, 110, 253); // Primary Blue
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 245);
            this.btnLogin.Name = "btnLogin.Click";
            this.btnLogin.Size = new System.Drawing.Size(290, 40);
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - MIEDU Lecturer Management";

            this.pnlLoginBox.ResumeLayout(false);
            this.pnlLoginBox.PerformLayout();
            this.pnlBackground.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
