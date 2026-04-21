// File: Presenters/LoginPresenter.cs
using System;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.DataAccess.Interfaces;

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

            // TODO: Trong thực tế, bạn cần mã hóa (Hash) _view.Password ở đây trước khi so sánh DB
            // Ở ví dụ này, giả sử mật khẩu trong DB lưu dạng plain text (không khuyến khích)
            // hoặc đã được mã hóa ở đâu đó tương ứng.
            string hashedPwd = _view.Password;

            var user = _repository.Authenticate(_view.Username, hashedPwd);

            if (user != null)
            {
                // Lưu thông tin người dùng đang đăng nhập vào Utils (để kiểm tra quyền sau này)
                // AppSession.CurrentUser = user; 
                _view.HideView();
                // MainForm sẽ được khởi tạo và hiển thị sau khi LoginForm đóng.
            }
            else
            {
                _view.ShowMessage("Tên đăng nhập hoặc mật khẩu không chính xác hoặc tài khoản bị khóa.");
            }
        }
    }
}
