// File: Models/Assignment.cs
using System;

namespace MIEDU_LecturerManagement.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }

        private int _semester;
        public int Semester
        {
            get => _semester;
            set
            {
                if (value < 1 || value > 3)
                    throw new ArgumentException("Lỗi: Học kỳ chỉ hợp lệ từ 1 đến 3.");
                _semester = value;
            }
        }

        public string AcademicYear { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; } = DateTime.Now;
    }
}
