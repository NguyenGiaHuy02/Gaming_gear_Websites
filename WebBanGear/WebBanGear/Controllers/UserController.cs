using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGear.Models;
using Model.EF;
using BotDetect.Web.Mvc;
using WebBanGear.Common;
using Model.Dao;

namespace WebBanGear.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangXuat()
        {
            Session[CommonConstrants.USER_SESSION] = null;
            Session[CommonConstrants.GioHangSession] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhap model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.Email, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetbyMaQuyen(model.Email);
                    var userSession = new UserLogin();
                    userSession.Email = user.Email;
                    userSession.UserMaQuyen = 2;
                    Session.Add(CommonConstrants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View(model);
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "dangkyCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult DangKy(DangKy model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var nguoidung = new NguoiDung();
                    nguoidung.HoTen = model.HoTen;
                    nguoidung.Email = model.Email;
                    nguoidung.DienThoai = model.DienThoai;
                    nguoidung.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                    nguoidung.MaQuyen = "2";
                    var result = dao.Insert(nguoidung);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(model);
        }
    }
}