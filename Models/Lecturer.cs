// File: Models/Lecturer.cs (Cập nhật)
using System.ComponentModel.DataAnnotations; // Bổ sung thư viện này

namespace MIEDU_LecturerManagement.Models
{
    public class Lecturer : Person
    {
        [Required(ErrorMessage = "Mã Giảng viên không được để trống.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Mã Giảng viên phải từ 3 đến 20 ký tự.")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn Khoa/Phòng ban.")]
        public int DepartmentId { get; set; }

        public string AcademicTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn Học vị.")]
        public string Degree { get; set; } = string.Empty;

        public override string GetPersonRole()
        {
            return "Giảng viên";
        }

        public override string GetDetailedInfo()
        {
            string baseInfo = base.GetDetailedInfo();
            string title = string.IsNullOrEmpty(AcademicTitle) ? Degree : $"{AcademicTitle}, {Degree}";
            return $"[{EmployeeCode}] {title}. {baseInfo}";
        }
    }
}
