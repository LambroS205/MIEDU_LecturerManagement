// File: Views/UserControls/LecturerViewControl.cs
using MIEDU_LecturerManagement.Views.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    public partial class LecturerViewControl : UserControl, ILecturerView
    {
        public LecturerViewControl()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        // Triển khai Properties của Interface
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SearchKeyword
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        // Triển khai Events của Interface
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler LoadEvent;
        public event EventHandler ExportEvent;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo");
        }

        public void SetLecturerListBindingSource(BindingSource lecturerList)
        {
            dgvLecturers.DataSource = lecturerList;

            // Cấu hình các cột cho DataGridView (Không hiển thị những cột ID không cần thiết)
            if (dgvLecturers.Columns.Count > 0)
            {
                dgvLecturers.Columns["PersonId"].Visible = false;
                dgvLecturers.Columns["UserId"].Visible = false;
                dgvLecturers.Columns["DepartmentId"].Visible = false;

                dgvLecturers.Columns["EmployeeCode"].HeaderText = "Mã GV";
                dgvLecturers.Columns["FullName"].HeaderText = "Họ và Tên"; // Đa hình/Đóng gói từ Person.FullName
                dgvLecturers.Columns["Email"].HeaderText = "Email";
                dgvLecturers.Columns["Phone"].HeaderText = "Điện thoại";
                dgvLecturers.Columns["AcademicTitle"].HeaderText = "Học hàm";
                dgvLecturers.Columns["Degree"].HeaderText = "Học vị";

                // Định dạng kích thước cột
                dgvLecturers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Bắn sự kiện LoadEvent khi UserControl vừa được tải lên màn hình
            this.Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };

            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };

            // Cho phép Enter để tìm kiếm
            txtSearch.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            btnAdd.Click += delegate { AddNewEvent?.Invoke(this, EventArgs.Empty); };
            btnEdit.Click += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
            btnDelete.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };
            btnExport.Click += delegate { ExportEvent?.Invoke(this, EventArgs.Empty); };
        }
    }
}
