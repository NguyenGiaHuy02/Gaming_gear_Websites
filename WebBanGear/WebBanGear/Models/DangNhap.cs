using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanGear.Models
{
    public class DangNhap
    {
        [Key]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn phải nhập email")]
        public string Email { set; get; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { set; get; }
    }
}