// File: Views/Interfaces/ILoginView.cs
using System;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }

        // Hiển thị thông báo (lỗi, thành công)
        void ShowMessage(string message);

        // Đóng form đăng nhập khi thành công
        void HideView();

        // Sự kiện khi người dùng nhấn nút Đăng nhập
        event EventHandler LoginAttemptEvent;
    }
}
