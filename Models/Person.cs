// File: Models/Person.cs
using System;

namespace MIEDU_LecturerManagement.Models
{
    public abstract class Person
    {
        // Tính đóng gói (Encapsulation): Sử dụng Properties get/set
        public int PersonId { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }

        // Đóng gói: Thuộc tính chỉ đọc (Read-only property) gộp họ và tên
        public string FullName => $"{LastName} {FirstName}";

        // Tính trừu tượng & Đa hình: Abstract method bắt buộc các lớp con phải tự định nghĩa
        public abstract string GetPersonRole();

        // Tính đa hình (Polymorphism): Virtual method cho phép lớp con ghi đè (Override)
        public virtual string GetDetailedInfo()
        {
            return $"Họ tên: {FullName} | Email: {Email} | SĐT: {Phone}";
        }
    }
}
