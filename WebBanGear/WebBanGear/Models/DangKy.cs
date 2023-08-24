using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebBanGear.Models
{
    public class DangKy
    {
        [Key]
        public int MaNguoiDung { set; get; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu điền email")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, ErrorMessage = "Độ dài ít nhất 6 kí tự.", MinimumLength = 6)]
        [Required(ErrorMessage = "Yêu cầu điền mật khẩu")]
        public string MatKhau { set; get; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không đúng!")]
        public string XacNhanMatKhau { set; get; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu điền họ tên")]
        public string HoTen { set; get; }
        [Display(Name = "Điện thoại")]
        public string DienThoai { set; get; }
    }
}