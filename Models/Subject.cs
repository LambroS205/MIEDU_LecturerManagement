// File: Models/Subject.cs
using System;

namespace MIEDU_LecturerManagement.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;

        private int _credits;

        // Tính đóng gói: Kiểm soát dữ liệu đầu vào của số tín chỉ
        public int Credits
        {
            get => _credits;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lỗi: Số tín chỉ môn học phải lớn hơn 0.");
                _credits = value;
            }
        }
    }
}
