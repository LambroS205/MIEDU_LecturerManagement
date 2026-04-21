// File: DataAccess/Repositories/SubjectRepository.cs
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        public IEnumerable<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();
            string query = "SELECT SubjectId, SubjectCode, SubjectName, Credits FROM Subjects ORDER BY SubjectName";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectId = Convert.ToInt32(reader["SubjectId"]),
                            SubjectCode = reader["SubjectCode"].ToString(),
                            SubjectName = reader["SubjectName"].ToString(),
                            Credits = Convert.ToInt32(reader["Credits"])
                        });
                    }
                }
            }
            return subjects;
        }
    }
}
