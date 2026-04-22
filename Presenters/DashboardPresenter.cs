// File: Presenters/DashboardPresenter.cs
using System;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.DataAccess.Interfaces;

namespace MIEDU_LecturerManagement.Presenters
{
    public class DashboardPresenter
    {
        private readonly IDashboardView _view;
        private readonly IDashboardRepository _repository;

        public DashboardPresenter(IDashboardView view, IDashboardRepository repository)
        {
            _view = view;
            _repository = repository;
            _view.LoadEvent += LoadDashboardData;
        }

        private void LoadDashboardData(object sender, EventArgs e)
        {
            var metrics = _repository.GetMetrics();

            // Cập nhật các thẻ số liệu
            _view.SetMetrics(metrics.TotalLecturers, metrics.TotalSubjects, metrics.TotalAssignments, metrics.TotalUsers);

            // Vẽ biểu đồ
            _view.DrawChart(metrics.LecturersByDepartment);
        }
    }
}
