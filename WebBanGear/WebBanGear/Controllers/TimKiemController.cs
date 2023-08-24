using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Model.ViewModel;
namespace WebBanGear.Controllers
{
    public class TimKiemController : Controller
    {
        [HttpGet]
        public ActionResult KQTiemKiem(string tukhoatk)
        {
            int page = 1;
            int pagesize = 10;
            var dao = new SanPhamDao();
            var model = dao.TimKiemSanPham(page, pagesize, tukhoatk);
            ViewBag.TuKhoa = tukhoatk;
            return View(model);
        }



        [HttpPost]
        public ActionResult TuKhoaTimKiem(string tukhoatk)
        {
            return RedirectToAction("KQTiemKiem", new { @tukhoatk = tukhoatk});
        }
    }
}