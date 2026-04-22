// File: Views/UserControls/DashboardViewControl.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;

namespace MIEDU_LecturerManagement.Views.UserControls
{
    public partial class DashboardViewControl : UserControl, IDashboardView
    {
        public DashboardViewControl()
        {
            InitializeComponent();
            this.Load += delegate { LoadEvent?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler LoadEvent;

        public void SetMetrics(int totalLecturers, int totalSubjects, int totalAssignments, int totalUsers)
        {
            lblTotalLecturers.Text = totalLecturers.ToString();
            lblTotalSubjects.Text = totalSubjects.ToString();
            lblTotalAssignments.Text = totalAssignments.ToString();
            lblTotalUsers.Text = totalUsers.ToString();
        }

        // Vẽ biểu đồ tự tạo bằng Code
        public void DrawChart(Dictionary<string, int> data)
        {
            pnlChartContainer.Controls.Clear();
            if (data == null || data.Count == 0) return;

            int maxCount = data.Values.Max();
            if (maxCount == 0) maxCount = 1; // Tránh chia cho 0

            int yPos = 20;
            int barHeight = 30;
            int maxWidth = pnlChartContainer.Width - 250; // Trừ hao lề cho chữ

            foreach (var item in data)
            {
                // Tên khoa
                var lblDept = new Label
                {
                    Text = item.Key,
                    Location = new Point(10, yPos + 5),
                    AutoSize = false,
                    Size = new Size(180, 20),
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleRight
                };

                // Tính toán độ dài thanh
                int barWidth = (int)((double)item.Value / maxCount * maxWidth);
                if (barWidth < 5) barWidth = 5; // Độ dài tối thiểu

                // Thanh bar (Màu nền)
                var pnlBarBg = new Panel
                {
                    Location = new Point(200, yPos),
                    Size = new Size(maxWidth, barHeight),
                    BackColor = Color.FromArgb(233, 236, 239) // Xám nhạt
                };

                // Thanh bar (Màu fill)
                var pnlBarFill = new Panel
                {
                    Location = new Point(0, 0),
                    Size = new Size(barWidth, barHeight),
                    BackColor = Color.FromArgb(13, 110, 253) // Xanh Blue
                };

                // Số lượng
                var lblValue = new Label
                {
                    Text = item.Value.ToString(),
                    Location = new Point(barWidth + 10, 5),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(73, 80, 87)
                };

                pnlBarBg.Controls.Add(pnlBarFill);
                pnlBarBg.Controls.Add(lblValue);

                pnlChartContainer.Controls.Add(lblDept);
                pnlChartContainer.Controls.Add(pnlBarBg);

                yPos += barHeight + 20; // Khoảng cách giữa các cột
            }
        }
    }
}
