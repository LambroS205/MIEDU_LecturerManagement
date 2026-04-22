// File: Presenters/MainPresenter.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.Utils;

namespace MIEDU_LecturerManagement.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;

            _mainView.ShowDashboardEvent += ShowDashboard;
            _mainView.ShowLecturersEvent += ShowLecturers;
            _mainView.ShowAssignmentsEvent += ShowAssignments;
            _mainView.ShowUsersEvent += ShowUsers;

            // Đảm bảo dòng này tồn tại để nối với sự kiện ở MainForm
            _mainView.LogoutEvent += Logout;

            SetupUserInfoAndPermissions();
            ShowDashboard();
        }

        private void SetupUserInfoAndPermissions()
        {
            if (AppSession.IsLoggedIn)
            {
                _mainView.SetUserInfo($"Xin chào, {AppSession.CurrentUser.Username} ({AppSession.CurrentUser.Role})");
                _mainView.ConfigureMenuAccess(AppSession.CurrentUser.Role);
            }
            else
            {
                _mainView.SetUserInfo("Chưa đăng nhập");
            }
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
            var presenter = new LecturerPresenter(_mainView, listView, detailView, repository);
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

        private void ShowUsers(object sender = null, EventArgs e = null)
        {
            var userView = new Views.UserControls.UserViewControl();
            var userRepo = new DataAccess.Repositories.UserRepository();
            var presenter = new UserPresenter(userView, userRepo);
            _mainView.ShowViewInMainContainer(userView);
        }

        private void Logout(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Xóa Session
                AppSession.ClearSession();

                // Ra lệnh đóng MainForm lại thay vì dùng Application.Restart()
                _mainView.CloseView();
            }
        }
    }
}