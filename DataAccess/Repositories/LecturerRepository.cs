// File: DataAccess/Repositories/LecturerRepository.cs
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        public IEnumerable<Lecturer> GetAllLecturers()
        {
            var lecturers = new List<Lecturer>();
            // JOIN 2 bảng và Sắp xếp tăng dần theo Tên, sau đó đến Họ (Nghiệp vụ cốt lõi)
            string query = @"
                SELECT p.PersonId, p.FirstName, p.LastName, p.Email, p.Phone, p.DateOfBirth,
                       l.EmployeeCode, l.DepartmentId, l.AcademicTitle, l.Degree
                FROM Persons p
                INNER JOIN Lecturers l ON p.PersonId = l.LecturerId
                ORDER BY p.FirstName ASC, p.LastName ASC";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lecturers.Add(MapReaderToLecturer(reader));
                    }
                }
            }
            return lecturers;
        }

        public IEnumerable<Lecturer> SearchLecturers(string keyword)
        {
            var lecturers = new List<Lecturer>();
            string query = @"
                SELECT p.PersonId, p.FirstName, p.LastName, p.Email, p.Phone, p.DateOfBirth,
                       l.EmployeeCode, l.DepartmentId, l.AcademicTitle, l.Degree
                FROM Persons p
                INNER JOIN Lecturers l ON p.PersonId = l.LecturerId
                WHERE p.FirstName LIKE @Keyword OR p.LastName LIKE @Keyword OR l.EmployeeCode LIKE @Keyword
                ORDER BY p.FirstName ASC";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lecturers.Add(MapReaderToLecturer(reader));
                    }
                }
            }
            return lecturers;
        }

        public void AddLecturer(Lecturer lecturer)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                // Sử dụng Transaction để đảm bảo tính toàn vẹn khi Insert vào 2 bảng
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert vào bảng cha (Persons) và lấy ID vừa tạo
                        string insertPersonQuery = @"
                            INSERT INTO Persons (FirstName, LastName, Email, Phone, DateOfBirth) 
                            OUTPUT INSERTED.PersonId 
                            VALUES (@FirstName, @LastName, @Email, @Phone, @DateOfBirth)";

                        int newPersonId;
                        using (var cmdPerson = new SqlCommand(insertPersonQuery, connection, transaction))
                        {
                            cmdPerson.Parameters.AddWithValue("@FirstName", lecturer.FirstName);
                            cmdPerson.Parameters.AddWithValue("@LastName", lecturer.LastName);
                            cmdPerson.Parameters.AddWithValue("@Email", (object)lecturer.Email ?? DBNull.Value);
                            cmdPerson.Parameters.AddWithValue("@Phone", (object)lecturer.Phone ?? DBNull.Value);
                            cmdPerson.Parameters.AddWithValue("@DateOfBirth", (object)lecturer.DateOfBirth ?? DBNull.Value);

                            newPersonId = (int)cmdPerson.ExecuteScalar();
                        }

                        // 2. Insert vào bảng con (Lecturers)
                        string insertLecturerQuery = @"
                            INSERT INTO Lecturers (LecturerId, EmployeeCode, DepartmentId, AcademicTitle, Degree) 
                            VALUES (@LecturerId, @EmployeeCode, @DepartmentId, @AcademicTitle, @Degree)";

                        using (var cmdLecturer = new SqlCommand(insertLecturerQuery, connection, transaction))
                        {
                            cmdLecturer.Parameters.AddWithValue("@LecturerId", newPersonId);
                            cmdLecturer.Parameters.AddWithValue("@EmployeeCode", lecturer.EmployeeCode);
                            cmdLecturer.Parameters.AddWithValue("@DepartmentId", lecturer.DepartmentId);
                            cmdLecturer.Parameters.AddWithValue("@AcademicTitle", (object)lecturer.AcademicTitle ?? DBNull.Value);
                            cmdLecturer.Parameters.AddWithValue("@Degree", (object)lecturer.Degree ?? DBNull.Value);

                            cmdLecturer.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Hoàn tất thành công
                    }
                    catch
                    {
                        transaction.Rollback(); // Nếu có lỗi, hoàn tác toàn bộ
                        throw;
                    }
                }
            }
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            // Tương tự Add, update cả 2 bảng thông qua Transaction.
            // Để tiết kiệm không gian, tôi chỉ minh họa khung sườn, thực tế bạn viết các câu lệnh UPDATE p... và UPDATE l...
            // ... (Code update)
        }

        public void DeleteLecturer(int lecturerId)
        {
            // Nhờ cấu hình ON DELETE CASCADE trong SQL, ta chỉ cần xóa Person, SQL tự xóa Lecturer.
            string query = "DELETE FROM Persons WHERE PersonId = @PersonId";
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonId", lecturerId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Hàm tiện ích để ánh xạ (Map) DataReader sang Object Lecturer
        private Lecturer MapReaderToLecturer(SqlDataReader reader)
        {
            return new Lecturer
            {
                PersonId = Convert.ToInt32(reader["PersonId"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,
                DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : (DateTime?)null,
                EmployeeCode = reader["EmployeeCode"].ToString(),
                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                AcademicTitle = reader["AcademicTitle"] != DBNull.Value ? reader["AcademicTitle"].ToString() : string.Empty,
                Degree = reader["Degree"] != DBNull.Value ? reader["Degree"].ToString() : string.Empty
            };
        }
    }
}