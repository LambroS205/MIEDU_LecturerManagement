// File: Presenters/LecturerPresenter.cs (Cập nhật toàn diện)
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MIEDU_LecturerManagement.Views.Interfaces;
using MIEDU_LecturerManagement.DataAccess.Interfaces;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Presenters
{
    public class LecturerPresenter
    {
        private readonly ILecturerView _listView;
        private readonly ILecturerDetailView _detailView;
        private readonly ILecturerRepository _repository;
        private readonly IMainView _mainView; // Cần thiết để chuyển đổi View

        private BindingSource _lecturersBindingSource;

        // Constructor mới nhận vào cả List View, Detail View và Main View
        public LecturerPresenter(IMainView mainView, ILecturerView listView, ILecturerDetailView detailView, ILecturerRepository repository)
        {
            _mainView = mainView;
            _listView = listView;
            _detailView = detailView;
            _repository = repository;
            _lecturersBindingSource = new BindingSource();

            // --- Đăng ký sự kiện cho List View ---
            _listView.LoadEvent += LoadAllLecturers;
            _listView.SearchEvent += SearchLecturers;
            _listView.AddNewEvent += OpenAddMode;
            _listView.EditEvent += OpenEditMode;
            _listView.DeleteEvent += DeleteLecturer;
            _listView.SetLecturerListBindingSource(_lecturersBindingSource);

            // --- Đăng ký sự kiện cho Detail View ---
            _detailView.SaveEvent += SaveLecturer;
            _detailView.CancelEvent += CancelAction;

            // Load Combobox Khoa (Giả lập, thực tế nên gọi IDepartmentRepository)
            LoadDepartmentsToComboBox();
        }

        private void LoadDepartmentsToComboBox()
        {
            var fakeDepts = new List<Department>
            {
                new Department { DepartmentId = 1, DepartmentName = "Công nghệ thông tin" },
                new Department { DepartmentId = 2, DepartmentName = "Kinh tế" },
                new Department { DepartmentId = 3, DepartmentName = "Ngoại ngữ" }
            };
            _detailView.SetDepartmentDataSource(fakeDepts, "DepartmentName", "DepartmentId");
        }

        // ================= XỬ LÝ DANH SÁCH =================
        private void LoadAllLecturers(object sender, EventArgs e)
        {
            _lecturersBindingSource.DataSource = _repository.GetAllLecturers();
        }

        private void SearchLecturers(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_listView.SearchKeyword))
                LoadAllLecturers(this, EventArgs.Empty);
            else
                _lecturersBindingSource.DataSource = _repository.SearchLecturers(_listView.SearchKeyword);
        }

        private void DeleteLecturer(object sender, EventArgs e)
        {
            var current = (Lecturer)_lecturersBindingSource.Current;
            if (current == null) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa giảng viên {current.FullName}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _repository.DeleteLecturer(current.PersonId);
                LoadAllLecturers(this, EventArgs.Empty);
            }
        }

        // ================= XỬ LÝ CHUYỂN TRANG =================
        private void OpenAddMode(object sender, EventArgs e)
        {
            _detailView.IsEditMode = false;
            ClearDetailForm();
            // Yêu cầu Main View hiển thị Detail Control thay vì List Control
            _mainView.ShowViewInMainContainer(_detailView);
        }

        private void OpenEditMode(object sender, EventArgs e)
        {
            var current = (Lecturer)_lecturersBindingSource.Current;
            if (current == null) return;

            _detailView.IsEditMode = true;
            _detailView.PersonId = current.PersonId;
            _detailView.FirstName = current.FirstName;
            _detailView.LastName = current.LastName;
            _detailView.Email = current.Email;
            _detailView.Phone = current.Phone;
            _detailView.DateOfBirth = current.DateOfBirth;
            _detailView.EmployeeCode = current.EmployeeCode;
            _detailView.DepartmentId = current.DepartmentId;
            _detailView.AcademicTitle = current.AcademicTitle;
            _detailView.Degree = current.Degree;

            _mainView.ShowViewInMainContainer(_detailView);
        }

        private void CancelAction(object sender, EventArgs e)
        {
            // Quay lại màn hình danh sách
            _mainView.ShowViewInMainContainer(_listView);
        }

        private void ClearDetailForm()
        {
            _detailView.PersonId = 0;
            _detailView.FirstName = string.Empty;
            _detailView.LastName = string.Empty;
            _detailView.Email = string.Empty;
            _detailView.Phone = string.Empty;
            _detailView.DateOfBirth = null;
            _detailView.EmployeeCode = string.Empty;
            // Đặt mặc định DepartmentId = 1 hoặc giá trị đầu tiên
            _detailView.AcademicTitle = string.Empty;
            _detailView.Degree = string.Empty;
        }

        // ================= XỬ LÝ LƯU (SAVE) =================
        private void SaveLecturer(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo Model (Thể hiện tính đóng gói)
                var lecturer = new Lecturer
                {
                    PersonId = _detailView.PersonId,
                    FirstName = _detailView.FirstName,
                    LastName = _detailView.LastName,
                    Email = _detailView.Email,
                    Phone = _detailView.Phone,
                    DateOfBirth = _detailView.DateOfBirth,
                    EmployeeCode = _detailView.EmployeeCode,
                    DepartmentId = _detailView.DepartmentId,
                    AcademicTitle = _detailView.AcademicTitle,
                    Degree = _detailView.Degree
                };

                // Basic Validation
                if (string.IsNullOrWhiteSpace(lecturer.FirstName) || string.IsNullOrWhiteSpace(lecturer.LastName) || string.IsNullOrWhiteSpace(lecturer.EmployeeCode))
                {
                    _detailView.ShowMessage("Vui lòng nhập đầy đủ Tên, Họ và Mã Giảng viên.");
                    return;
                }

                if (_detailView.IsEditMode)
                {
                    _repository.UpdateLecturer(lecturer);
                    _detailView.ShowMessage("Cập nhật thành công!");
                }
                else
                {
                    _repository.AddLecturer(lecturer);
                    _detailView.ShowMessage("Thêm mới thành công!");
                }

                // Thành công thì quay về List và tải lại dữ liệu
                LoadAllLecturers(this, EventArgs.Empty);
                _mainView.ShowViewInMainContainer(_listView);
            }
            catch (Exception ex)
            {
                _detailView.ShowMessage($"Đã có lỗi xảy ra: {ex.Message}");
            }
        }
    }
}
