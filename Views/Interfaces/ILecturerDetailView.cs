// File: Views/Interfaces/ILecturerDetailView.cs
using System;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface ILecturerDetailView
    {
        // Các thuộc tính ánh xạ với UI Controls
        int PersonId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        DateTime? DateOfBirth { get; set; }
        string EmployeeCode { get; set; }
        int DepartmentId { get; set; }
        string AcademicTitle { get; set; }
        string Degree { get; set; }

        bool IsEditMode { get; set; } // Phân biệt trạng thái Thêm hay Sửa

        // Sự kiện
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // Tiện ích
        void ShowMessage(string message);
        void SetDepartmentDataSource(object dataSource, string displayMember, string valueMember);
    }
}
