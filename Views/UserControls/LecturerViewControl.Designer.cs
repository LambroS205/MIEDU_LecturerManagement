// File: Views/UserControls/LecturerViewControl.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    partial class LecturerViewControl
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTopBar;
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnExport; // Nút Export mới
        private DataGridView dgvLecturers;

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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvLecturers = new System.Windows.Forms.DataGridView();

            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.btnExport);
            this.pnlTopBar.Controls.Add(this.btnDelete);
            this.pnlTopBar.Controls.Add(this.btnEdit);
            this.pnlTopBar.Controls.Add(this.btnAdd);
            this.pnlTopBar.Controls.Add(this.btnSearch);
            this.pnlTopBar.Controls.Add(this.txtSearch);
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(910, 80);
            this.pnlTopBar.Paint += (sender, e) => {
                ControlPaint.DrawBorder(e.Graphics, this.pnlTopBar.ClientRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.FromArgb(222, 226, 230), 1, ButtonBorderStyle.Solid);
            };

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(15, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Danh sách Giảng viên";

            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(250, 30); // Đã dịch trái
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm theo tên, mã GV...";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);

            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(460, 29); // Đã dịch trái
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 27);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;

            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(550, 29); // Đã dịch trái
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 27);
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;

            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(640, 29); // Đã dịch trái
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 27);
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.UseVisualStyleBackColor = false;

            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(730, 29); // Đã dịch trái
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;

            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(13, 202, 240); // Cyan nổi bật
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(820, 29); // Nằm góc phải
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 27);
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;

            // 
            // dgvLecturers
            // 
            this.dgvLecturers.AllowUserToAddRows = false;
            this.dgvLecturers.AllowUserToDeleteRows = false;
            this.dgvLecturers.BackgroundColor = System.Drawing.Color.White;
            this.dgvLecturers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLecturers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLecturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLecturers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLecturers.Location = new System.Drawing.Point(0, 80);
            this.dgvLecturers.Name = "dgvLecturers";
            this.dgvLecturers.ReadOnly = true;
            this.dgvLecturers.RowHeadersVisible = false;
            this.dgvLecturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLecturers.Size = new System.Drawing.Size(910, 520);

            this.dgvLecturers.EnableHeadersVisualStyles = false;
            this.dgvLecturers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvLecturers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.dgvLecturers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvLecturers.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvLecturers.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(204, 229, 255);
            this.dgvLecturers.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvLecturers.RowTemplate.Height = 35;
            this.dgvLecturers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // 
            // LecturerViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvLecturers);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "LecturerViewControl";
            this.Size = new System.Drawing.Size(910, 600);

            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
