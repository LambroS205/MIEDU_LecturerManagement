// File: Views/UserControls/UserViewControl.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    public partial class UserViewControl : UserControl, IUserView
    {
        public UserViewControl()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public event EventHandler LoadEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;

        public void SetUserListBindingSource(BindingSource userList)
        {
            dgvUsers.DataSource = userList;
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["UserId"].Visible = false;
                dgvUsers.Columns["PasswordHash"].Visible = false; // Luôn ẩn cột mật khẩu

                dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
                dgvUsers.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUsers.Columns["Role"].HeaderText = "Phân quyền";
                dgvUsers.Columns["IsActive"].HeaderText = "Trạng thái (Active)";
            }
        }

        private void AssociateAndRaiseViewEvents()
        {
            this.Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
            btnAdd.Click += delegate { AddEvent?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            btnDelete.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };
        }
    }
}
