// File: DataAccess/Repositories/UserRepository.cs (Cập nhật & Bổ sung)
using System;
using System.Collections.Generic;
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
                            Role = reader["Role"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                    }
                }
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            string query = "SELECT UserId, Username, Role, IsActive FROM Users ORDER BY Username";
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString(),
                            Role = reader["Role"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
            }
            return users;
        }

        public void AddUser(User user)
        {
            string query = "INSERT INTO Users (Username, PasswordHash, Role, IsActive) VALUES (@Username, @PasswordHash, @Role, @IsActive)";
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user, bool updatePassword)
        {
            string query = updatePassword
                ? "UPDATE Users SET Role = @Role, IsActive = @IsActive, PasswordHash = @PasswordHash WHERE UserId = @UserId"
                : "UPDATE Users SET Role = @Role, IsActive = @IsActive WHERE UserId = @UserId";

            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                if (updatePassword) command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserId = @UserId";
            using (var connection = DatabaseConnection.GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
