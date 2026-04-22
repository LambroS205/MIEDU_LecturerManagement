// File: Views/Forms/MainForm.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.Forms
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public event EventHandler ShowDashboardEvent;
        public event EventHandler ShowLecturersEvent;
        public event EventHandler ShowAssignmentsEvent;
        public event EventHandler ShowUsersEvent;
        public event EventHandler LogoutEvent;

        public void ShowViewInMainContainer(object view)
        {
            pnlMainContent.Controls.Clear();
            if (view is Control control)
            {
                control.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(control);
            }
        }

        public void SetUserInfo(string info)
        {
            lblUserInfo.Text = info;
            lblUserInfo.Left = pnlTopBar.Width - lblUserInfo.Width - 20;
        }

        public void ConfigureMenuAccess(string role)
        {
            if (btnHome != null) btnHome.Visible = true;
            if (btnManageLecturers != null) btnManageLecturers.Visible = true;
            if (btnLogout != null) btnLogout.Visible = true;

            if (role == "Admin")
            {
                if (btnManageAssignments != null) btnManageAssignments.Visible = true;
                var btnUsers = this.Controls.Find("btnManageUsers", true);
                if (btnUsers.Length > 0) btnUsers[0].Visible = true;
            }
            else if (role == "Staff")
            {
                if (btnManageAssignments != null) btnManageAssignments.Visible = true;
                var btnUsers = this.Controls.Find("btnManageUsers", true);
                if (btnUsers.Length > 0) btnUsers[0].Visible = false;
            }
            else if (role == "Lecturer")
            {
                if (btnManageAssignments != null) btnManageAssignments.Visible = false;
                var btnUsers = this.Controls.Find("btnManageUsers", true);
                if (btnUsers.Length > 0) btnUsers[0].Visible = false;
            }
        }

        // Thực thi hàm CloseView
        public void CloseView()
        {
            this.Close();
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Sử dụng cú pháp (sender, e) => để đảm bảo code không bao giờ bị lỗi delegate
            if (btnHome != null)
                btnHome.Click += (s, e) => ShowDashboardEvent?.Invoke(this, EventArgs.Empty);

            if (btnManageLecturers != null)
                btnManageLecturers.Click += (s, e) => ShowLecturersEvent?.Invoke(this, EventArgs.Empty);

            if (btnManageAssignments != null)
                btnManageAssignments.Click += (s, e) => ShowAssignmentsEvent?.Invoke(this, EventArgs.Empty);

            var btnManageUsers = this.Controls.Find("btnManageUsers", true);
            if (btnManageUsers.Length > 0)
                btnManageUsers[0].Click += (s, e) => ShowUsersEvent?.Invoke(this, EventArgs.Empty);

            // Bắt sự kiện đăng xuất
            if (btnLogout != null)
                btnLogout.Click += (s, e) => LogoutEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}