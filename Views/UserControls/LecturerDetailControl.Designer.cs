// File: Views/UserControls/LecturerDetailControl.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    partial class LecturerDetailControl
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblFirstName; private TextBox txtFirstName;
        private Label lblLastName; private TextBox txtLastName;
        private Label lblEmail; private TextBox txtEmail;
        private Label lblPhone; private TextBox txtPhone;
        private Label lblDob; private DateTimePicker dtpDateOfBirth;
        private Label lblEmpCode; private TextBox txtEmployeeCode;
        private Label lblDept; private ComboBox cboDepartment;
        private Label lblTitleAcademic; private ComboBox cboAcademicTitle;
        private Label lblDegree; private ComboBox cboDegree;

        private Button btnSave;
        private Button btnCancel;
        private Panel pnlContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();

            // Khởi tạo controls
            this.lblLastName = new System.Windows.Forms.Label(); this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label(); this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label(); this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label(); this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblDob = new System.Windows.Forms.Label(); this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblEmpCode = new System.Windows.Forms.Label(); this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.lblDept = new System.Windows.Forms.Label(); this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblTitleAcademic = new System.Windows.Forms.Label(); this.cboAcademicTitle = new System.Windows.Forms.ComboBox();
            this.lblDegree = new System.Windows.Forms.Label(); this.cboDegree = new System.Windows.Forms.ComboBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Thêm mới Giảng viên";

            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Location = new System.Drawing.Point(25, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 380);

            // Cột trái (Tọa độ X = 30)
            int col1_X = 30; int start_Y = 30; int gap_Y = 50; int inputWidth = 300;

            SetupField(lblLastName, txtLastName, "Họ (và đệm):", col1_X, start_Y, inputWidth);
            SetupField(lblDob, dtpDateOfBirth, "Ngày sinh:", col1_X, start_Y + gap_Y, inputWidth);
            SetupField(lblEmail, txtEmail, "Email:", col1_X, start_Y + gap_Y * 2, inputWidth);
            SetupField(lblEmpCode, txtEmployeeCode, "Mã Giảng viên (*):", col1_X, start_Y + gap_Y * 3, inputWidth);
            SetupField(lblTitleAcademic, cboAcademicTitle, "Học hàm:", col1_X, start_Y + gap_Y * 4, inputWidth);

            // Thêm data mẫu cho ComboBox Học hàm
            this.cboAcademicTitle.Items.AddRange(new object[] { "", "Giáo sư", "Phó giáo sư" });
            this.cboAcademicTitle.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cột phải (Tọa độ X = 400)
            int col2_X = 400;

            SetupField(lblFirstName, txtFirstName, "Tên (*):", col2_X, start_Y, inputWidth);
            SetupField(lblPhone, txtPhone, "Số điện thoại:", col2_X, start_Y + gap_Y, inputWidth);
            SetupField(lblDept, cboDepartment, "Thuộc Khoa (*):", col2_X, start_Y + gap_Y * 2, inputWidth);
            this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            SetupField(lblDegree, cboDegree, "Học vị (*):", col2_X, start_Y + gap_Y * 3, inputWidth);
            this.cboDegree.Items.AddRange(new object[] { "Cử nhân", "Thạc sĩ", "Tiến sĩ", "Tiến sĩ khoa học" });
            this.cboDegree.DropDownStyle = ComboBoxStyle.DropDownList;

            // Buttons
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(520, 310);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Lưu";
            this.btnSave.Cursor = Cursors.Hand;

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(630, 310);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Cursor = Cursors.Hand;

            this.pnlContent.Controls.AddRange(new Control[] {
                lblLastName, txtLastName, lblFirstName, txtFirstName,
                lblDob, dtpDateOfBirth, lblEmail, txtEmail, lblPhone, txtPhone,
                lblEmpCode, txtEmployeeCode, lblDept, cboDepartment,
                lblTitleAcademic, cboAcademicTitle, lblDegree, cboDegree,
                btnSave, btnCancel
            });

            // 
            // LecturerDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "LecturerDetailControl";
            this.Size = new System.Drawing.Size(910, 600);

            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm hỗ trợ để rút gọn code tạo Layout
        private void SetupField(Label lbl, Control input, string text, int x, int y, int width)
        {
            lbl.Text = text;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9.5F);

            input.Location = new Point(x, y + 22);
            input.Size = new Size(width, 25);
            input.Font = new Font("Segoe UI", 10F);

            if (input is DateTimePicker dtp)
            {
                dtp.Format = DateTimePickerFormat.Short;
                dtp.ShowCheckBox = true; // Cho phép null
            }
        }
    }
}