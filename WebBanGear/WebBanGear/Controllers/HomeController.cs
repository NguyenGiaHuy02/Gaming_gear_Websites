using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGear.Models;

namespace WebBanGear.Controllers
{
    public class HomeController : Controller
    {
        private string GioHangSession = "GioHangSession";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[GioHangSession];
            var list = new List<SanPhamGioHang>();
            if (cart != null)
            {
                list = (List<SanPhamGioHang>)cart;
            }
            return PartialView(list);
        }
    }
}