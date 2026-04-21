// File: DataAccess/Interfaces/ISubjectRepository.cs
using System.Collections.Generic;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Interfaces
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects();
    }
}
