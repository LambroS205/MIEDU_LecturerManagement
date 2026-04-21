// File: DataAccess/Interfaces/IAssignmentRepository.cs
using System.Collections.Generic;
using System.Data;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Interfaces
{
    public interface IAssignmentRepository
    {
        // Trả về DataTable để tiện binding hiển thị có Join tên Giảng viên và Tên môn
        DataTable GetAllAssignmentsView();
        void AddAssignment(Assignment assignment);
        void DeleteAssignment(int assignmentId);
    }
}