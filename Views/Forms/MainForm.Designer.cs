// File: Views/Forms/MainForm.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls cho Sidebar
        private Panel pnlSidebar;
        private Panel pnlLogo;
        private Label lblLogo;
        private Button btnManageLecturers;
        private Button btnManageAssignments;
        private Button btnManageUsers;
        private Button btnLogout;

        // Controls cho Topbar và Nội dung chính
        private Panel pnlTopBar;
        private Label lblUserInfo;
        private Panel pnlMainContent;

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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnManageLecturers = new System.Windows.Forms.Button();
            this.btnManageAssignments = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(33, 37, 41); // Dark Gray cho Sidebar
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnManageAssignments);
            this.pnlSidebar.Controls.Add(this.btnManageLecturers);
            this.pnlSidebar.Controls.Add(this.btnManageUsers);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 700);

            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(25, 28, 31);
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(250, 60);

            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(20, 15);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Text = "MIEDU Portal";

            // 
            // btnManageLecturers
            // 
            this.btnManageLecturers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageLecturers.FlatAppearance.BorderSize = 0;
            this.btnManageLecturers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageLecturers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageLecturers.ForeColor = System.Drawing.Color.FromArgb(206, 212, 218);
            this.btnManageLecturers.Location = new System.Drawing.Point(0, 60);
            this.btnManageLecturers.Name = "btnManageLecturers";
            this.btnManageLecturers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageLecturers.Size = new System.Drawing.Size(250, 50);
            this.btnManageLecturers.Text = "Quản lý Giảng viên";
            this.btnManageLecturers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageLecturers.UseVisualStyleBackColor = true;
            this.btnManageLecturers.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // btnManageAssignments
            // 
            this.btnManageAssignments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageAssignments.FlatAppearance.BorderSize = 0;
            this.btnManageAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAssignments.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageAssignments.ForeColor = System.Drawing.Color.FromArgb(206, 212, 218);
            this.btnManageAssignments.Location = new System.Drawing.Point(0, 110);
            this.btnManageAssignments.Name = "btnManageAssignments";
            this.btnManageAssignments.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageAssignments.Size = new System.Drawing.Size(250, 50);
            this.btnManageAssignments.Text = "Phân công Môn học";
            this.btnManageAssignments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageAssignments.UseVisualStyleBackColor = true;
            this.btnManageAssignments.Cursor = System.Windows.Forms.Cursors.Hand;

            //
            // btnManageUsers
            //
            this.btnManageUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageUsers.ForeColor = System.Drawing.Color.FromArgb(206, 212, 218);
            this.btnManageUsers.Location = new System.Drawing.Point(0, 160); // 160 = 110 (Y của btnAssignments) + 50 (Chiều cao)
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageUsers.Size = new System.Drawing.Size(250, 50);
            this.btnManageUsers.Text = "Hệ thống / Users";
            this.btnManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(206, 212, 218);
            this.btnLogout.Location = new System.Drawing.Point(0, 650);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(250, 50);
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblUserInfo);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(250, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(950, 60);
            // Thêm border bottom giả
            this.pnlTopBar.Paint += (sender, e) => {
                ControlPaint.DrawBorder(e.Graphics, this.pnlTopBar.ClientRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.lblUserInfo.Location = new System.Drawing.Point(800, 20);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Text = "Xin chào, User";

            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(248, 249, 250); // Rất nhạt, gần trắng
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(250, 60);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainContent.Size = new System.Drawing.Size(950, 640);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - MIEDU Lecturer Management";

            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
