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

            // Đăng ký sự kiện
            _mainView.ShowLecturersEvent += ShowLecturers;
            _mainView.ShowAssignmentsEvent += ShowAssignments;
            _mainView.LogoutEvent += Logout;

            // Thiết lập thông tin (Giả lập, thực tế lấy từ AppSession.CurrentUser)
            _mainView.SetUserInfo("Xin chào, Admin");
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
            Label lblTemp = new Label { Text = "Đây là màn hình Phân công môn học", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter, Font = new System.Drawing.Font("Segoe UI", 16) };
            _mainView.ShowViewInMainContainer(lblTemp);
        }

        private void Logout(object sender, EventArgs e)
        {
            // Xử lý đăng xuất (Ví dụ: Khởi động lại ứng dụng)
            Application.Restart();
        }
    }
}