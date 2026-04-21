// File: Views/Forms/LoginForm.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.Forms
{
    public partial class LoginForm : Form, ILoginView
    {
        public LoginForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        // Triển khai Interface ILoginView
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        public event EventHandler LoginAttemptEvent;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void HideView()
        {
            this.DialogResult = DialogResult.OK; // Báo cho Program.cs biết đăng nhập thành công
            this.Close();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnLogin.Click += delegate { LoginAttemptEvent?.Invoke(this, EventArgs.Empty); };

            // Cho phép nhấn Enter để đăng nhập
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    LoginAttemptEvent?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
