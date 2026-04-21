// File: Views/Forms/UserDetailForm.cs
using System;
using System.Drawing;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Models;
using MIEDU_LecturerManagement.Utils;

namespace MIEDU_LecturerManagement.Views.Forms
{
    public partial class UserDetailForm : Form
    {
        public User UserInfo { get; private set; }
        public bool IsPasswordChanged => !string.IsNullOrEmpty(txtPassword.Text);

        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cboRole;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;
        private bool _isEditMode;

        public UserDetailForm(User user = null)
        {
            _isEditMode = user != null;
            UserInfo = user ?? new User { IsActive = true, Role = "Lecturer" };
            InitializeComponentManual();
            LoadDataToForm();
        }

        private void LoadDataToForm()
        {
            if (_isEditMode)
            {
                txtUsername.Text = UserInfo.Username;
                txtUsername.ReadOnly = true; // Không cho sửa Username
                cboRole.Text = UserInfo.Role;
                chkIsActive.Checked = UserInfo.IsActive;
            }
            else
            {
                cboRole.SelectedIndex = 1; // Mặc định là Lecturer
                chkIsActive.Checked = true;
            }
        }

        private void InitializeComponentManual()
        {
            this.Text = _isEditMode ? "Chỉnh sửa Tài khoản" : "Thêm Tài khoản mới";
            this.Size = new Size(350, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int startY = 20; int gap = 60;

            // Username
            var lblUser = new Label { Text = "Tên đăng nhập (*):", Location = new Point(20, startY), AutoSize = true };
            txtUsername = new TextBox { Location = new Point(20, startY + 20), Width = 290, Font = new Font("Segoe UI", 10) };

            // Password
            string pwdLabel = _isEditMode ? "Mật khẩu (Để trống nếu không đổi):" : "Mật khẩu (*):";
            var lblPass = new Label { Text = pwdLabel, Location = new Point(20, startY + gap), AutoSize = true };
            txtPassword = new TextBox { Location = new Point(20, startY + gap + 20), Width = 290, Font = new Font("Segoe UI", 10), PasswordChar = '•' };

            // Role
            var lblRole = new Label { Text = "Quyền (Role):", Location = new Point(20, startY + gap * 2), AutoSize = true };
            cboRole = new ComboBox { Location = new Point(20, startY + gap * 2 + 20), Width = 290, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10) };
            cboRole.Items.AddRange(new object[] { "Admin", "Lecturer", "Staff" });

            // IsActive
            chkIsActive = new CheckBox { Text = "Kích hoạt (Cho phép đăng nhập)", Location = new Point(20, startY + gap * 3 + 10), AutoSize = true, Font = new Font("Segoe UI", 10) };

            // Buttons
            btnSave = new Button { Text = "Lưu", Location = new Point(130, startY + gap * 4), Width = 80, Height = 35, BackColor = Color.FromArgb(13, 110, 253), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(230, startY + gap * 4), Width = 80, Height = 35, BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lblUser, txtUsername, lblPass, txtPassword, lblRole, cboRole, chkIsActive, btnSave, btnCancel });
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu cho tài khoản mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserInfo.Username = txtUsername.Text.Trim();
            UserInfo.Role = cboRole.Text;
            UserInfo.IsActive = chkIsActive.Checked;

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                // Băm mật khẩu trước khi gán vào Model
                UserInfo.PasswordHash = SecurityHelper.HashPassword(txtPassword.Text);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
