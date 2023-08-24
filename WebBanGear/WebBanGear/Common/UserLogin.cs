using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Dao;
using Model.EF;
namespace WebBanGear.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserMaQuyen { set; get; }
        public string Email { set; get; }
        public int MaNguoiDung { get; set; }
        public NguoiDung getNguoiDung(string email)
        {
            var dao = new UserDao();
            var user = dao.GetbyMaQuyen(email);
            return user;
        }
    }
}