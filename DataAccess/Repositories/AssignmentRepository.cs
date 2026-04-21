// File: DataAccess/Repositories/AssignmentRepository.cs
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        public DataTable GetAllAssignmentsView()
        {
            var dt = new DataTable();
            string query = @"
                SELECT a.AssignmentId, 
                       l.EmployeeCode AS [Mã GV], 
                       p.LastName + ' ' + p.FirstName AS [Tên Giảng Viên],
                       s.SubjectCode AS [Mã Môn], 
                       s.SubjectName AS [Tên Môn Học],
                       a.Semester AS [Học Kỳ], 
                       a.AcademicYear AS [Năm Học]
                FROM Assignments a
                INNER JOIN Lecturers l ON a.LecturerId = l.LecturerId
                INNER JOIN Persons p ON l.LecturerId = p.PersonId
                INNER JOIN Subjects s ON a.SubjectId = s.SubjectId
                ORDER BY a.AcademicYear DESC, a.Semester DESC, p.FirstName ASC";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public void AddAssignment(Assignment assignment)
        {
            string query = @"
                INSERT INTO Assignments (LecturerId, SubjectId, Semester, AcademicYear, AssignedDate)
                VALUES (@LecturerId, @SubjectId, @Semester, @AcademicYear, GETDATE())";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LecturerId", assignment.LecturerId);
                command.Parameters.AddWithValue("@SubjectId", assignment.SubjectId);
                command.Parameters.AddWithValue("@Semester", assignment.Semester);
                command.Parameters.AddWithValue("@AcademicYear", assignment.AcademicYear);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAssignment(int assignmentId)
        {
            string query = "DELETE FROM Assignments WHERE AssignmentId = @AssignmentId";
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@AssignmentId", assignmentId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
