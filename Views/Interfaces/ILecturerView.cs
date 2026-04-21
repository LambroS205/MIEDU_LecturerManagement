// File: Views/Interfaces/ILecturerView.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms; // Để dùng BindingSource
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Views.Interfaces
{
    public interface ILecturerView
    {
        // Properties để lấy dữ liệu từ View (dùng cho Tìm kiếm, Thêm, Sửa)
        string SearchKeyword { get; set; }

        // Nhận dữ liệu từ Presenter để hiển thị lên DataGridView
        void SetLecturerListBindingSource(BindingSource lecturerList);

        // Sự kiện
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler LoadEvent; // Khi View vừa được mở lên
    }
}
