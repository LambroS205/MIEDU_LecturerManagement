// File: Presenters/MainPresenter.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;
// using MIEDU_LecturerManagement.Utils; // Nếu có class lưu AppSession

namespace MIEDU_LecturerManagement.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;

            ShowDashboard();
            // Đăng ký sự kiện
            _mainView.ShowDashboardEvent += ShowDashboard;
            _mainView.ShowLecturersEvent += ShowLecturers;
            _mainView.ShowAssignmentsEvent += ShowAssignments;
            _mainView.ShowUsersEvent += ShowUsers;
            _mainView.LogoutEvent += Logout;

            // Thiết lập thông tin (Giả lập, thực tế lấy từ AppSession.CurrentUser)
            _mainView.SetUserInfo("Xin chào, Admin");

        }

        private void ShowDashboard(object sender = null, EventArgs e = null)
        {
            var dashboardView = new Views.UserControls.DashboardViewControl();
            var dashboardRepo = new DataAccess.Repositories.DashboardRepository();
            var presenter = new DashboardPresenter(dashboardView, dashboardRepo);

            _mainView.ShowViewInMainContainer(dashboardView);
        }

        private void ShowLecturers(object sender, EventArgs e)
        {
            var listView = new Views.UserControls.LecturerViewControl();
            var detailView = new Views.UserControls.LecturerDetailControl();
            var repository = new DataAccess.Repositories.LecturerRepository();

            // Truyền this (_mainView) vào để Presenter có thể thực hiện chuyển đổi View
            var presenter = new LecturerPresenter(_mainView, listView, detailView, repository);

            // Ban đầu hiển thị danh sách
            _mainView.ShowViewInMainContainer(listView);
        }

        private void ShowAssignments(object sender, EventArgs e)
        {
            var assignmentView = new Views.UserControls.AssignmentViewControl();
            var assignmentRepo = new DataAccess.Repositories.AssignmentRepository();
            var lecturerRepo = new DataAccess.Repositories.LecturerRepository();
            var subjectRepo = new DataAccess.Repositories.SubjectRepository();

            var presenter = new AssignmentPresenter(assignmentView, assignmentRepo, lecturerRepo, subjectRepo);

            _mainView.ShowViewInMainContainer(assignmentView);
        }

        private void ShowUsers(object sender, EventArgs e)
        {
            var userView = new Views.UserControls.UserViewControl();
            var userRepo = new DataAccess.Repositories.UserRepository();
            var presenter = new UserPresenter(userView, userRepo);
            _mainView.ShowViewInMainContainer(userView);
        }

        private void Logout(object sender, EventArgs e)
        {
            // Xử lý đăng xuất (Ví dụ: Khởi động lại ứng dụng)
            Application.Restart();
        }
    }
}