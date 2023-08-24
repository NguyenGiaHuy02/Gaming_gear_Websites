using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGear.Models;
using Model.Dao;
using System.Web.Script.Serialization;
using Model.EF;
using WebBanGear.Common;
namespace WebBanGear.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            var cart = Session[CommonConstrants.GioHangSession];
            var list = new List<SanPhamGioHang>();
            if(cart != null)
            {
                list = (List<SanPhamGioHang>)cart;
            }
            return View(list);
        }
        public JsonResult Update(string giohangModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<SanPhamGioHang>>(giohangModel);
            var sessionCart = (List<SanPhamGioHang>)Session[CommonConstrants.GioHangSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsoncart.SingleOrDefault(x => x.sanpham.MaSanPham == item.sanpham.MaSanPham);
                if(jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CommonConstrants.GioHangSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(string masp)
        {
            var sessionCart = (List<SanPhamGioHang>)Session[CommonConstrants.GioHangSession];
            sessionCart.RemoveAll(x => x.sanpham.MaSanPham == masp);
            Session[CommonConstrants.GioHangSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult ThemSanPham(string masp , int soluong)
        {
            var sanpham = new SanPhamDao().ChiTietSanPham(masp);
            var cart = Session[CommonConstrants.GioHangSession];
            if(cart != null)
            {
                var list = (List<SanPhamGioHang>)cart;
                if(list.Exists(x => x.sanpham.MaSanPham == masp))
                {
                    foreach (var item in list)
                    {
                        if (item.sanpham.MaSanPham == masp)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                }
                else
                {
                    var item = new SanPhamGioHang();
                    foreach(var product in sanpham)
                    {
                        item.sanpham = product;
                    }
                    item.SoLuong = soluong;
                    list.Add(item);
                }
                
            }
            else
            {
                //Tạo sản phẩm trong giỏ hàng
                var item = new SanPhamGioHang();
                foreach (var product in sanpham)
                {
                    item.sanpham = product;
                }
                item.SoLuong = soluong;
                var list = new List<SanPhamGioHang>();
                list.Add(item);
                // Gán vào session
                Session[CommonConstrants.GioHangSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstrants.GioHangSession];
            var list = new List<SanPhamGioHang>();
            if (cart != null)
            {
                list = (List<SanPhamGioHang>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(int manguoidung)
        {
            var donhang = new DonHang();
            donhang.NgayMua = DateTime.Now.Date;
            donhang.TinhTrang = "Confirmed";
            donhang.MaNguoiDung = manguoidung;
            try
            {
                var id = new DonHangDao().Insert(donhang);
                var cart = (List<SanPhamGioHang>)Session[CommonConstrants.GioHangSession];
                var ChiTietDao = new ChiTietDonHangDao();
                foreach (var item in cart)
                {
                    var chitietdonhang = new ChiTietDonHang();
                    chitietdonhang.MaDon = id;
                    chitietdonhang.MaSanPham = item.sanpham.MaSanPham;
                    chitietdonhang.SoLuong = item.SoLuong;
                    chitietdonhang.DonGia = item.sanpham.GiaTien;
                    chitietdonhang.NgayGiao = donhang.NgayMua.Value.AddDays(3);
                    ChiTietDao.Insert(chitietdonhang);
                }
            }
            catch
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult SuccessPay()
        {
            var cart = Session[CommonConstrants.GioHangSession];
            var list = new List<SanPhamGioHang>();
            if (cart != null)
            {
                list = (List<SanPhamGioHang>)cart;
            }
            return View(list);
        }
        public ActionResult FailtPay()
        {
            return View();
        }
        public JsonResult DeleteAll()
        {
            Session[CommonConstrants.GioHangSession] = null;
            return Json(new
            {
                status = true
            });
        }
    }
}