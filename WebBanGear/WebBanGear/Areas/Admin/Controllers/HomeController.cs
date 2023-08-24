using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
namespace WebBanGear.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TableSanPham()
        {
            var dao = new SanPhamDao();
            var db = dao.ListAll();
            return View(db);
        }
        public ActionResult TableLoaiSanPham()
        {
            var dao = new LoaiSanPhamDao();
            var db = dao.ListAll();
            return View(db);
        }
        public ActionResult TableNguoiDung()
        {
            var dao = new UserDao();
            var db = dao.ListAll();
            return View(db);
        }
        public ActionResult TableDonHang()
        {
            var dao = new DonHangDao();
            var db = dao.ListAll();
            return View(db);
        }
        public ActionResult TableHinhAnhSanPham()
        {
            var dao = new HinhAnhDao();
            var db = dao.ListAll();
            return View(db);
        }


    }
}