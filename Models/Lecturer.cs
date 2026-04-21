// File: Models/Lecturer.cs
namespace MIEDU_LecturerManagement.Models
{
    // Kế thừa từ Person
    public class Lecturer : Person
    {
        public string EmployeeCode { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string AcademicTitle { get; set; } = string.Empty; // Học hàm
        public string Degree { get; set; } = string.Empty; // Học vị

        // Tính đa hình: Bắt buộc override abstract method của lớp cha
        public override string GetPersonRole()
        {
            return "Giảng viên";
        }

        // Tính đa hình: Override lại virtual method để hiển thị thêm chức danh
        public override string GetDetailedInfo()
        {
            // Gọi lại method của lớp cha qua từ khóa 'base'
            string baseInfo = base.GetDetailedInfo();
            string title = string.IsNullOrEmpty(AcademicTitle) ? Degree : $"{AcademicTitle}, {Degree}";

            return $"[{EmployeeCode}] {title}. {baseInfo}";
        }
    }
}