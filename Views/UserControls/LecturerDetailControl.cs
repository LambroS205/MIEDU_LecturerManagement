using System;
using System.ComponentModel; // Bổ sung thư viện này
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    public partial class LecturerDetailControl : UserControl, ILecturerDetailView
    {
        public LecturerDetailControl()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        // Thêm [Browsable(false)] và [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        // vào TẤT CẢ các properties thuộc Interface để tránh lỗi Designer

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PersonId { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FirstName { get => txtFirstName.Text; set => txtFirstName.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName { get => txtLastName.Text; set => txtLastName.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Phone { get => txtPhone.Text; set => txtPhone.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? DateOfBirth
        {
            get => dtpDateOfBirth.Checked ? dtpDateOfBirth.Value : (DateTime?)null;
            set
            {
                if (value.HasValue)
                {
                    dtpDateOfBirth.Value = value.Value;
                    dtpDateOfBirth.Checked = true;
                }
                else dtpDateOfBirth.Checked = false;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EmployeeCode { get => txtEmployeeCode.Text; set => txtEmployeeCode.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DepartmentId
        {
            get => cboDepartment.SelectedValue != null ? Convert.ToInt32(cboDepartment.SelectedValue) : 0;
            set => cboDepartment.SelectedValue = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AcademicTitle { get => cboAcademicTitle.Text; set => cboAcademicTitle.Text = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Degree { get => cboDegree.Text; set => cboDegree.Text = value; }

        private bool _isEditMode;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                lblTitle.Text = _isEditMode ? "Chỉnh sửa thông tin Giảng viên" : "Thêm mới Giảng viên";
                txtEmployeeCode.ReadOnly = _isEditMode; // Thường mã nhân viên không được sửa
            }
        }

        // Events
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        // Methods
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Thông báo");
        }

        public void SetDepartmentDataSource(object dataSource, string displayMember, string valueMember)
        {
            cboDepartment.DataSource = dataSource;
            cboDepartment.DisplayMember = displayMember;
            cboDepartment.ValueMember = valueMember;
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSave.Click += delegate { SaveEvent?.Invoke(this, EventArgs.Empty); };
            btnCancel.Click += delegate { CancelEvent?.Invoke(this, EventArgs.Empty); };
        }
    }
}