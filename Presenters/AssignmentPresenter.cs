// File: Presenters/AssignmentPresenter.cs
using System;
using System.Data;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.Views.Forms;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Presenters
{
    public class AssignmentPresenter
    {
        private readonly IAssignmentView _view;
        private readonly IAssignmentRepository _repository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly ISubjectRepository _subjectRepository;
        private BindingSource _bindingSource;

        public AssignmentPresenter(IAssignmentView view, IAssignmentRepository repository, ILecturerRepository lecturerRepository, ISubjectRepository subjectRepository)
        {
            _view = view;
            _repository = repository;
            _lecturerRepository = lecturerRepository;
            _subjectRepository = subjectRepository;
            _bindingSource = new BindingSource();

            _view.LoadEvent += LoadAllAssignments;
            _view.AddNewEvent += AddAssignment;
            _view.DeleteEvent += DeleteAssignment;

            _view.SetAssignmentListBindingSource(_bindingSource);
        }

        private void LoadAllAssignments(object sender, EventArgs e)
        {
            _bindingSource.DataSource = _repository.GetAllAssignmentsView();
        }

        private void AddAssignment(object sender, EventArgs e)
        {
            var lecturers = _lecturerRepository.GetAllLecturers();
            var subjects = _subjectRepository.GetAllSubjects();

            using (var form = new AssignmentAddForm(lecturers, subjects))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var assignment = new Assignment
                        {
                            LecturerId = form.SelectedLecturerId,
                            SubjectId = form.SelectedSubjectId,
                            Semester = form.Semester,
                            AcademicYear = form.AcademicYear
                        };
                        _repository.AddAssignment(assignment);
                        LoadAllAssignments(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}");
                    }
                }
            }
        }

        private void DeleteAssignment(object sender, EventArgs e)
        {
            var current = (DataRowView)_bindingSource.Current;
            if (current == null) return;

            int id = Convert.ToInt32(current["AssignmentId"]);
            if (MessageBox.Show("Xác nhận xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repository.DeleteAssignment(id);
                LoadAllAssignments(this, EventArgs.Empty);
            }
        }
    }
}
