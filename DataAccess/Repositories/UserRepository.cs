// File: DataAccess/Repositories/UserRepository.cs
using System;
using Microsoft.Data.SqlClient;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Authenticate(string username, string passwordHash)
        {
            User user = null;
            string query = "SELECT UserId, Username, PasswordHash, Role, IsActive FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash AND IsActive = 1";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString(),
                            Role = reader["Role"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                    }
                }
            }
            return user;
        }
    }
}