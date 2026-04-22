// File: DataAccess/Repositories/DashboardRepository.cs
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        public DashboardMetrics GetMetrics()
        {
            var metrics = new DashboardMetrics();
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                // Lấy tổng số liệu (Sử dụng Multiple Result Sets để tối ưu, chỉ cần 1 lần truy vấn)
                string queryTotals = @"
                    SELECT COUNT(*) FROM Lecturers;
                    SELECT COUNT(*) FROM Subjects;
                    SELECT COUNT(*) FROM Assignments;
                    SELECT COUNT(*) FROM Users;
                    
                    SELECT d.DepartmentName, COUNT(l.LecturerId) as Total
                    FROM Departments d
                    LEFT JOIN Lecturers l ON d.DepartmentId = l.DepartmentId
                    GROUP BY d.DepartmentName
                    ORDER BY Total DESC;";

                using (var command = new SqlCommand(queryTotals, connection))
                using (var reader = command.ExecuteReader())
                {
                    // Đọc Dataset 1: Lecturers
                    if (reader.Read()) metrics.TotalLecturers = Convert.ToInt32(reader[0]);

                    // Đọc Dataset 2: Subjects
                    reader.NextResult();
                    if (reader.Read()) metrics.TotalSubjects = Convert.ToInt32(reader[0]);

                    // Đọc Dataset 3: Assignments
                    reader.NextResult();
                    if (reader.Read()) metrics.TotalAssignments = Convert.ToInt32(reader[0]);

                    // Đọc Dataset 4: Users
                    reader.NextResult();
                    if (reader.Read()) metrics.TotalUsers = Convert.ToInt32(reader[0]);

                    // Đọc Dataset 5: Biểu đồ
                    reader.NextResult();
                    while (reader.Read())
                    {
                        string deptName = reader["DepartmentName"].ToString();
                        int count = Convert.ToInt32(reader["Total"]);
                        metrics.LecturersByDepartment.Add(deptName, count);
                    }
                }
            }
            return metrics;
        }
    }
}
