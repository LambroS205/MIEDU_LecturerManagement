// File: Models/DashboardMetrics.cs
using System.Collections.Generic;

namespace MIEDU_LecturerManagement.Models
{
    public class DashboardMetrics
    {
        public int TotalLecturers { get; set; }
        public int TotalSubjects { get; set; }
        public int TotalAssignments { get; set; }
        public int TotalUsers { get; set; }
        // Dùng Dictionary để lưu tên Khoa và số lượng Giảng viên tương ứng
        public Dictionary<string, int> LecturersByDepartment { get; set; } = new Dictionary<string, int>();
    }
}
