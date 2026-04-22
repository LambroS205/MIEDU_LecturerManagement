// File: Utils/ValidationHelper.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MIEDU_LecturerManagement.Utils
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Kiểm tra tính hợp lệ của một đối tượng Model dựa trên DataAnnotations.
        /// </summary>
        /// <param name="model">Đối tượng cần kiểm tra</param>
        /// <param name="errorMessage">Chuỗi chứa tất cả các lỗi (nếu có)</param>
        /// <returns>True nếu hợp lệ, False nếu có lỗi</returns>
        public static bool ValidateModel<T>(T model, out string errorMessage)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            // false: Chỉ check [Required], true: check toàn bộ các thuộc tính
            bool isValid = Validator.TryValidateObject(model, context, results, true);

            if (!isValid)
            {
                // Gộp tất cả các câu thông báo lỗi thành một danh sách có gạch đầu dòng
                var errors = results.Select(r => $"- {r.ErrorMessage}");
                errorMessage = string.Join("\n", errors);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}