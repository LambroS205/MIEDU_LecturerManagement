// File: Utils/ExportHelper.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MIEDU_LecturerManagement.Models;

namespace MIEDU_LecturerManagement.Utils
{
    public static class ExportHelper
    {
        public static void ExportLecturersToCSV(IEnumerable<Lecturer> lecturers, string filePath)
        {
            // Sử dụng UTF8Encoding(true) để tạo BOM (Byte Order Mark)
            // Nhờ đó Excel sẽ tự động nhận diện đây là file UTF-8 và hiển thị tiếng Việt chuẩn 100%.
            using (StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                // Ghi Header (Tiêu đề các cột)
                sw.WriteLine("Mã Giảng Viên,Họ và Tên,Email,Điện thoại,Ngày sinh,Học hàm,Học vị,Thuộc Khoa (ID)");

                // Ghi từng dòng dữ liệu
                foreach (var l in lecturers)
                {
                    string dob = l.DateOfBirth?.ToString("dd/MM/yyyy") ?? "";

                    // Cần bao bọc dữ liệu trong dấu ngoặc kép "" để tránh lỗi nếu dữ liệu có chứa dấu phẩy (,)
                    string line = $"\"{l.EmployeeCode}\",\"{l.FullName}\",\"{l.Email}\",\"{l.Phone}\",\"{dob}\",\"{l.AcademicTitle}\",\"{l.Degree}\",\"{l.DepartmentId}\"";

                    sw.WriteLine(line);
                }
            }
        }
    }
}
