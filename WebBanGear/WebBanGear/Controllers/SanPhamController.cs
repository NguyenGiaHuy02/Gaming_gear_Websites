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
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult SanPhamTrangChu()
        {
            ViewBag.BanPhim = new SanPhamDao().ListSanPhamVaHinhAnh('3'.ToString());
            ViewBag.Chuot = new SanPhamDao().ListSanPhamVaHinhAnh('2'.ToString());
            ViewBag.TaiNghe = new SanPhamDao().ListSanPhamVaHinhAnh('1'.ToString());
            return PartialView();
        }

        public ActionResult DanhMucSanPham(char id)
        {
            int page = 1;
            int pagesize = 10;
            var dao = new SanPhamDao();
            var model = dao.ListAllItemPageACType(page, pagesize, id.ToString());
            return View(model);
        }

        public ActionResult DanhMucSanPhamTheoHang(int mahang , char maloai)
        {
            int page = 1;
            int pagesize = 10;
            var dao = new SanPhamDao();
            var model = dao.ListAllItemPageACManu(page, pagesize, mahang , maloai.ToString());
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DanhMucSanPhamKhac(char maloai)
        {
            int page = 1;
            int pagesize = 10;
            var dao = new SanPhamDao();
            var model = dao.ListAllItemPageOthers(page, pagesize, maloai.ToString());
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult DanhMucSanPhamHang(int mahang)
        {
            int page = 1;
            int pagesize = 10;
            var dao = new SanPhamDao();
            var model = dao.ListAllItemPageManuFac(page, pagesize, mahang);
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult ChiTietSanPham(string masanpham)
        {
            var dao = new SanPhamDao();
            var model = dao.ChiTietSanPhamBanPhim(masanpham);
            if(model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult ChiTietSanPhamChuot(string masanpham)
        {
            var dao = new SanPhamDao();
            var model = dao.ChiTietSanPhamChuot(masanpham);
            if(model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult ChiTietSanPhamTaiNghe(string masanpham)
        {
            var dao = new SanPhamDao();
            var model = dao.ChiTietSanPhamTaiNghe(masanpham);
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult ChiTietSanPhamTheoLoai(string masanpham , string maloai)
        {
            if(maloai.Equals("Tai Nghe"))
            {
                return RedirectToAction("ChiTietSanPhamTaiNghe", "SanPham", new { masanpham = masanpham }); 
            }
            else if(maloai.Equals("Chuột"))
            {
                return RedirectToAction("ChiTietSanPhamChuot", "SanPham", new { masanpham = masanpham });
            }
            else
            {
                return RedirectToAction("ChiTietSanPham", "SanPham", new { masanpham = masanpham });
            }
        }
    }
}