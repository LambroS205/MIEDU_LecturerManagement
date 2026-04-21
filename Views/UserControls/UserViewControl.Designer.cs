// File: Views/UserControls/UserViewControl.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    partial class UserViewControl
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTopBar;
        private Label lblTitle;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();

            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            // Top Bar
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.AddRange(new Control[] { this.btnDelete, this.btnEdit, this.btnAdd, this.lblTitle });
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Size = new System.Drawing.Size(910, 80);

            // Lbl
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 25);
            this.lblTitle.Text = "Quản lý Hệ thống (Tài khoản)";

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(640, 29);
            this.btnAdd.Size = new System.Drawing.Size(80, 27);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.btnEdit.Location = new System.Drawing.Point(730, 29);
            this.btnEdit.Size = new System.Drawing.Size(80, 27);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.btnDelete.Location = new System.Drawing.Point(820, 29);
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Grid
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 80);
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvUsers.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvUsers.RowTemplate.Height = 35;

            // UserViewControl
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlTopBar);
            this.Size = new System.Drawing.Size(910, 600);

            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
