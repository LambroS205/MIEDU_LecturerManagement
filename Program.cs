// File: Program.cs (Cập nhật)
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Forms;
using MIEDU_LecturerManagement.Presenters;
using MIEDU_LecturerManagement.DataAccess.Repositories;

namespace MIEDU_LecturerManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginView = new LoginForm();
            var userRepository = new UserRepository();
            var loginPresenter = new LoginPresenter(loginView, userRepository);

            Application.Run(loginView);

            // Nếu đăng nhập thành công
            if (loginView.DialogResult == DialogResult.OK)
            {
                var mainView = new MainForm();
                var mainPresenter = new MainPresenter(mainView);

                // Khởi chạy MainForm
                Application.Run(mainView);
            }
        }
    }
}
