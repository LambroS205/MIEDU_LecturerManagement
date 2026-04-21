// File: Presenters/UserPresenter.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.Views.Forms;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Presenters
{
    public class UserPresenter
    {
        private readonly IUserView _view;
        private readonly IUserRepository _repository;
        private BindingSource _bindingSource;

        public UserPresenter(IUserView view, IUserRepository repository)
        {
            _view = view;
            _repository = repository;
            _bindingSource = new BindingSource();

            _view.LoadEvent += LoadUsers;
            _view.AddEvent += AddUser;
            _view.EditEvent += EditUser;
            _view.DeleteEvent += DeleteUser;

            _view.SetUserListBindingSource(_bindingSource);
        }

        private void LoadUsers(object sender, EventArgs e)
        {
            _bindingSource.DataSource = _repository.GetAllUsers();
        }

        private void AddUser(object sender, EventArgs e)
        {
            using (var form = new UserDetailForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _repository.AddUser(form.UserInfo);
                        LoadUsers(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm: {ex.Message}");
                    }
                }
            }
        }

        private void EditUser(object sender, EventArgs e)
        {
            var currentUser = (User)_bindingSource.Current;
            if (currentUser == null) return;

            using (var form = new UserDetailForm(currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _repository.UpdateUser(form.UserInfo, form.IsPasswordChanged);
                    LoadUsers(this, EventArgs.Empty);
                }
            }
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            var currentUser = (User)_bindingSource.Current;
            if (currentUser == null) return;

            if (currentUser.Username.ToLower() == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản Admin mặc định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa tài khoản {currentUser.Username}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repository.DeleteUser(currentUser.UserId);
                LoadUsers(this, EventArgs.Empty);
            }
        }
    }
}
