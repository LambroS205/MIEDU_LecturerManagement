// File: Utils/AppSession.cs
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Utils
{
    public static class AppSession
    {
        // Lưu trữ thông tin người dùng hiện tại
        public static User CurrentUser { get; set; }

        // Hàm tiện ích kiểm tra xem đã đăng nhập chưa
        public static bool IsLoggedIn => CurrentUser != null;

        // Hàm xóa phiên đăng nhập (Dùng khi Đăng xuất)
        public static void ClearSession()
        {
            CurrentUser = null;
        }
    }
}
