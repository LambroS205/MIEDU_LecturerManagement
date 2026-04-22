// File: Views/Interfaces/IDashboardView.cs
using System;
using System.Collections.Generic;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface IDashboardView
    {
        void SetMetrics(int totalLecturers, int totalSubjects, int totalAssignments, int totalUsers);
        void DrawChart(Dictionary<string, int> data);
        event EventHandler LoadEvent;
    }
}
