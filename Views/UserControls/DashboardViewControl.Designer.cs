// File: Views/UserControls/DashboardViewControl.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    partial class DashboardViewControl
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private FlowLayoutPanel flpCards;
        private Panel pnlChartSection;
        private Label lblChartTitle;
        private Panel pnlChartContainer;

        // Nhãn để chứa số lượng
        private Label lblTotalLecturers;
        private Label lblTotalSubjects;
        private Label lblTotalAssignments;
        private Label lblTotalUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlChartSection = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.pnlChartContainer = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Tổng quan Hệ thống";

            // 
            // flpCards (Khu vực chứa các thẻ số liệu)
            // 
            this.flpCards.Location = new System.Drawing.Point(25, 70);
            this.flpCards.Size = new System.Drawing.Size(860, 130);
            this.flpCards.WrapContents = false; // Xếp trên 1 hàng ngang

            // Tạo 4 Card bằng code
            lblTotalLecturers = new Label();
            flpCards.Controls.Add(CreateCard("Tổng Giảng viên", lblTotalLecturers, Color.FromArgb(13, 110, 253))); // Blue

            lblTotalSubjects = new Label();
            flpCards.Controls.Add(CreateCard("Tổng Môn học", lblTotalSubjects, Color.FromArgb(25, 135, 84))); // Green

            lblTotalAssignments = new Label();
            flpCards.Controls.Add(CreateCard("Số Lượt Phân công", lblTotalAssignments, Color.FromArgb(255, 193, 7))); // Yellow

            lblTotalUsers = new Label();
            flpCards.Controls.Add(CreateCard("Tài khoản Hệ thống", lblTotalUsers, Color.FromArgb(220, 53, 69))); // Red

            // 
            // pnlChartSection (Khu vực biểu đồ)
            // 
            this.pnlChartSection.BackColor = System.Drawing.Color.White;
            this.pnlChartSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartSection.Location = new System.Drawing.Point(25, 230);
            this.pnlChartSection.Size = new System.Drawing.Size(860, 340);

            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle.Text = "Thống kê Giảng viên theo Khoa";

            this.pnlChartContainer.Location = new System.Drawing.Point(15, 60);
            this.pnlChartContainer.Size = new System.Drawing.Size(830, 260);
            this.pnlChartContainer.AutoScroll = true; // Cho phép cuộn nếu nhiều khoa

            this.pnlChartSection.Controls.Add(this.lblChartTitle);
            this.pnlChartSection.Controls.Add(this.pnlChartContainer);

            // 
            // DashboardViewControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.Controls.Add(this.pnlChartSection);
            this.Controls.Add(this.flpCards);
            this.Controls.Add(this.lblTitle);
            this.Size = new System.Drawing.Size(910, 600);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm hỗ trợ tạo các Card số liệu (Tái sử dụng code)
        private Panel CreateCard(string title, Label lblValue, Color topBorderColor)
        {
            var pnl = new Panel { Size = new Size(200, 110), BackColor = Color.White, Margin = new Padding(0, 0, 15, 0) };

            // Viền màu ở trên cùng
            var topBorder = new Panel { Dock = DockStyle.Top, Height = 4, BackColor = topBorderColor };

            var lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 10F, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(15, 20), AutoSize = true };

            lblValue.Text = "0";
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue.ForeColor = Color.FromArgb(33, 37, 41);
            lblValue.Location = new Point(15, 45);
            lblValue.AutoSize = true;

            pnl.Controls.Add(topBorder);
            pnl.Controls.Add(lblTitle);
            pnl.Controls.Add(lblValue);

            // Vẽ border mờ xung quanh Card
            pnl.Paint += (sender, e) => {
                ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.FromArgb(222, 226, 230), ButtonBorderStyle.Solid);
            };

            return pnl;
        }
    }
}
