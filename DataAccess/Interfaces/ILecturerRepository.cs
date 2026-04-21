// File: DataAccess/Interfaces/ILecturerRepository.cs
using System.Collections.Generic;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Interfaces
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> GetAllLecturers();
        IEnumerable<Lecturer> SearchLecturers(string keyword);
        void AddLecturer(Lecturer lecturer);
        void UpdateLecturer(Lecturer lecturer);
        void DeleteLecturer(int lecturerId);
    }
}
