// File: Views/Interfaces/IMainView.cs
using System;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface IMainView
    {
        event EventHandler ShowDashboardEvent;
        event EventHandler ShowLecturersEvent;
        event EventHandler ShowAssignmentsEvent;
        event EventHandler ShowUsersEvent;
        event EventHandler LogoutEvent;

        void ShowViewInMainContainer(object view);
        void SetUserInfo(string info);
        void ConfigureMenuAccess(string role);

        // Thêm hàm này để Presenter có thể ra lệnh đóng Form Main
        void CloseView();
    }
}