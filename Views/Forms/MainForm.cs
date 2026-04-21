// File: Views/Forms/MainForm.cs
using System;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.Forms
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        // Triển khai IMainView
        public event EventHandler ShowLecturersEvent;
        public event EventHandler ShowAssignmentsEvent;
        public event EventHandler LogoutEvent;

        public void ShowViewInMainContainer(object view)
        {
            pnlMainContent.Controls.Clear();
            if (view is Control control)
            {
                control.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(control);
            }
        }

        public void SetUserInfo(string info)
        {
            lblUserInfo.Text = info;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnManageLecturers.Click += delegate { ShowLecturersEvent?.Invoke(this, EventArgs.Empty); };
            btnManageAssignments.Click += delegate { ShowAssignmentsEvent?.Invoke(this, EventArgs.Empty); };
            btnLogout.Click += delegate { LogoutEvent?.Invoke(this, EventArgs.Empty); };
        }
    }
}