using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Views.Forms
{
    // Đã thêm từ khóa "partial" vào đây
    public partial class AssignmentAddForm : Form
    {
        public int SelectedLecturerId => (int)cboLecturer.SelectedValue;
        public int SelectedSubjectId => (int)cboSubject.SelectedValue;
        public int Semester => Convert.ToInt32(numSemester.Value);
        public string AcademicYear => txtAcademicYear.Text;

        private ComboBox cboLecturer;
        private ComboBox cboSubject;
        private NumericUpDown numSemester;
        private TextBox txtAcademicYear;
        private Button btnSave;
        private Button btnCancel;

        public AssignmentAddForm(IEnumerable<Lecturer> lecturers, IEnumerable<Subject> subjects)
        {
            InitializeComponentManual(lecturers, subjects);
        }

        // Đổi tên hàm thành InitializeComponentManual để tránh trùng với hàm tự sinh của VS (nếu có)
        private void InitializeComponentManual(IEnumerable<Lecturer> lecturers, IEnumerable<Subject> subjects)
        {
            this.Text = "Phân công giảng dạy";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int startY = 20; int gap = 60;

            // Giảng viên
            var lblLec = new Label { Text = "Chọn Giảng viên:", Location = new Point(20, startY), AutoSize = true };
            cboLecturer = new ComboBox { Location = new Point(20, startY + 20), Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLecturer.DataSource = lecturers.ToList();
            cboLecturer.DisplayMember = "FullName";
            cboLecturer.ValueMember = "PersonId";

            // Môn học
            var lblSub = new Label { Text = "Chọn Môn học:", Location = new Point(20, startY + gap), AutoSize = true };
            cboSubject = new ComboBox { Location = new Point(20, startY + gap + 20), Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
            cboSubject.DataSource = subjects.ToList();
            cboSubject.DisplayMember = "SubjectName";
            cboSubject.ValueMember = "SubjectId";

            // Học kỳ
            var lblSem = new Label { Text = "Học kỳ:", Location = new Point(20, startY + gap * 2), AutoSize = true };
            numSemester = new NumericUpDown { Location = new Point(20, startY + gap * 2 + 20), Width = 100, Minimum = 1, Maximum = 3 };

            // Năm học
            var lblYear = new Label { Text = "Năm học (VD: 2023-2024):", Location = new Point(150, startY + gap * 2), AutoSize = true };
            txtAcademicYear = new TextBox { Location = new Point(150, startY + gap * 2 + 20), Width = 210, Text = "2023-2024" };

            // Nút
            btnSave = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Location = new Point(180, startY + gap * 3 + 10), Width = 80, BackColor = Color.FromArgb(13, 110, 253), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.FlatAppearance.BorderSize = 0;

            btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(280, startY + gap * 3 + 10), Width = 80, BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lblLec, cboLecturer, lblSub, cboSubject, lblSem, numSemester, lblYear, txtAcademicYear, btnSave, btnCancel });
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }
    }
}