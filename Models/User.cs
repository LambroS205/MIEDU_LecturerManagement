// File: Models/User.cs
namespace MIEDU_LecturerManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Admin", "Lecturer", "Staff"
        public bool IsActive { get; set; } = true;
    }
}
