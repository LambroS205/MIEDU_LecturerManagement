// File: DataAccess/Interfaces/IDashboardRepository.cs
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.DataAccess.Interfaces
{
    public interface IDashboardRepository
    {
        DashboardMetrics GetMetrics();
    }
}