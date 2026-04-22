// File: Program.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Forms;
using MIEDU_LecturerManagement.Presenters;
using MIEDU_LecturerManagement.DataAccess.Repositories;
using MIEDU_LecturerManagement.Utils; // Bổ sung thư viện

namespace MIEDU_LecturerManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool showLogin = true;

            // Vòng lặp quản lý vòng đời ứng dụng
            while (showLogin)
            {
                showLogin = false; // Mặc định là thoát ứng dụng

                using (var loginView = new LoginForm())
                {
                    var userRepository = new UserRepository();
                    var loginPresenter = new LoginPresenter(loginView, userRepository);

                    // Nếu người dùng đăng nhập thành công
                    if (loginView.ShowDialog() == DialogResult.OK)
                    {
                        using (var mainView = new MainForm())
                        {
                            var mainPresenter = new MainPresenter(mainView);

                            // Khởi chạy Dashboard chính
                            Application.Run(mainView);

                            // Khi MainForm bị đóng (do bấm X, hoặc do bấm Đăng xuất)
                            // Ta kiểm tra xem có phải do bấm Đăng xuất không (Session bị xóa = null)
                            if (!AppSession.IsLoggedIn)
                            {
                                showLogin = true; // Bật lại cờ để vòng lặp while quay lại mở LoginForm
                            }
                        }
                    }
                }
            }
        }
    }
}