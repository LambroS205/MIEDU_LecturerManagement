// File: Views/Interfaces/IMainView.cs
using System;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface IMainView
    {
        // Sự kiện khi nhấn các nút trên Sidebar
        event EventHandler ShowLecturersEvent;
        event EventHandler ShowAssignmentsEvent;
        event EventHandler ShowUsersEvent;
        event EventHandler LogoutEvent;

        // Phương thức để nhúng UserControl/View con vào vùng nội dung chính
        void ShowViewInMainContainer(object view);

        // Cập nhật thông tin người dùng đang đăng nhập
        void SetUserInfo(string info);
    }
}
