using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebBanGear.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { set; get; }
    }
}