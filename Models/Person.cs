// File: Models/Person.cs (Cập nhật)
using System;
using System.ComponentModel.DataAnnotations; // Bổ sung thư viện này

namespace MIEDU_LecturerManagement.Models
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Tên không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ (và đệm) không được để trống.")]
        [StringLength(50, ErrorMessage = "Họ không được vượt quá 50 ký tự.")]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public abstract string GetPersonRole();

        public virtual string GetDetailedInfo()
        {
            return $"Họ tên: {FullName} | Email: {Email} | SĐT: {Phone}";
        }
    }
}
