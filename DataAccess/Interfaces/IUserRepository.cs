// File: DataAccess/Interfaces/IUserRepository.cs
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string username, string passwordHash);
    }
}