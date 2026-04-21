// File: DataAccess/Interfaces/IUserRepository.cs (Cập nhật)
using System.Collections.Generic;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string username, string passwordHash);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user, bool updatePassword);
        void DeleteUser(int userId);
    }
}
