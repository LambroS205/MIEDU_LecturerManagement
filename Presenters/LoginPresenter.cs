using System;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Utils; // Bổ sung thư viện Utils chứa SecurityHelper

namespace MIEDU_LecturerManagement.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly IUserRepository _repository;

        public LoginPresenter(ILoginView view, IUserRepository repository)
        {
            _view = view;
            _repository = repository;

            // Đăng ký sự kiện
            _view.LoginAttemptEvent += TryLogin;
        }

        private void TryLogin(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.Username) || string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowMessage("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            // [ĐÃ SỬA]: Sử dụng SecurityHelper để băm mật khẩu người dùng nhập vào
            // trước khi mang xuống CSDL so sánh
            string hashedPwd = SecurityHelper.HashPassword(_view.Password);

            var user = _repository.Authenticate(_view.Username, hashedPwd);

            if (user != null)
            {
                // TODO: Lưu thông tin Session ở đây (nếu làm Bước 9)
                _view.HideView();
            }
            else
            {
                _view.ShowMessage("Tên đăng nhập hoặc mật khẩu không chính xác hoặc tài khoản bị khóa.");
            }
        }
    }
}