// File: Views/UserControls/AssignmentViewControl.cs
using System;
using System.ComponentModel;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    public partial class AssignmentViewControl : UserControl, IAssignmentView
    {
        public AssignmentViewControl()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public event EventHandler LoadEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler DeleteEvent;

        public void SetAssignmentListBindingSource(BindingSource assignmentList)
        {
            dgvAssignments.DataSource = assignmentList;
            if (dgvAssignments.Columns.Count > 0)
            {
                dgvAssignments.Columns["AssignmentId"].Visible = false;
                dgvAssignments.Columns["Tên Giảng Viên"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAssignments.Columns["Tên Môn Học"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void AssociateAndRaiseViewEvents()
        {
            this.Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            btnDelete.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };
        }
    }
}
