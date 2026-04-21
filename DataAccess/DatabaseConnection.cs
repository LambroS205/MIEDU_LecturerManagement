// File: DataAccess/DatabaseConnection.cs
using Microsoft.Data.SqlClient;

namespace MIEDU_LecturerManagement.DataAccess
{
    public sealed class DatabaseConnection
    {
        // Thay đổi ServerName và chuỗi kết nối cho phù hợp với máy của bạn
        // Ví dụ: "Server=.\\SQLEXPRESS;Database=MIEDU_LecturerManagement;Trusted_Connection=True;"
        private static readonly string _connectionString = @"Server=WIN-5DITV6K7REC\SQLEXPRESS;Database=MIEDU_LecturerManagement;Integrated Security=True;TrustServerCertificate=True;";

        private DatabaseConnection() { }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
