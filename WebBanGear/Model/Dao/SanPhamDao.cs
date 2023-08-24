using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;
using System.Drawing;
using System.IO;
using PagedList.Mvc;
using PagedList;
namespace Model.Dao
{
    public class SanPhamDao
    {
        QuanLyBanGearDbContext db = null;
        public SanPhamDao()
        {
            db = new QuanLyBanGearDbContext();
        }
        public List<SanPham> ListAll()
        {
            return db.SanPhams.ToList();
        }
        public List<SanPhamViewModel> ListSanPhamVaHinhAnh(string MaLoai)
        {
            var model = from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.HangSanXuats
                        on a.MaHangSanXuat equals c.MaHangSanXuat
                        join d in db.LoaiSanPhams
                        on a.MaLoai equals d.MaLoai
                        where a.MaLoai == MaLoai
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = c.TenHang,
                            TenLoai = d.TenLoai
                        };
            return model.ToList();
        }
        public List<SanPhamViewModel> ChiTietSanPham(string id)
        {
            var model = from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.HangSanXuats
                        on a.MaHangSanXuat equals c.MaHangSanXuat
                        join d in db.LoaiSanPhams
                        on a.MaLoai equals d.MaLoai
                        where a.MaSanPham == id
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = c.TenHang,
                            TenLoai = d.TenLoai
                        };
            return model.ToList();
        }
        public SanPham ViewDetail(string id)
        {
            return db.SanPhams.Find(id);
        }
       

        public IEnumerable<SanPhamViewModel> ListAllItemPageACType(int page,int pagesize,string MaLoai)
        {
            var dssp = (from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.LoaiSanPhams
                        on a.MaLoai equals c.MaLoai
                        join d in db.HangSanXuats
                        on a.MaHangSanXuat equals d.MaHangSanXuat
                        where a.MaLoai == MaLoai
                        orderby a.GiaTien descending
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = d.TenHang,
                            TenLoai = c.TenLoai
                        });
            return dssp.ToPagedList(page,pagesize);        
        }
        public IEnumerable<SanPhamViewModel> ListAllItemPageACManu(int page, int pagesize, int MaHang,string MaLoai)
        {
            var dssp = (from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.LoaiSanPhams
                        on a.MaLoai equals c.MaLoai
                        join d in db.HangSanXuats
                        on a.MaHangSanXuat equals d.MaHangSanXuat
                        where ((a.MaHangSanXuat == MaHang)&& (a.MaLoai == MaLoai))
                        orderby a.GiaTien descending
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = d.TenHang,
                            TenLoai = c.TenLoai
                        }) ;
            return dssp.ToPagedList(page, pagesize);
        }
        public IEnumerable<SanPhamViewModel> ListAllItemPageOthers(int page, int pagesize , string MaLoai)
        {
            var dssp = (from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.LoaiSanPhams
                        on a.MaLoai equals c.MaLoai
                        join d in db.HangSanXuats
                        on a.MaHangSanXuat equals d.MaHangSanXuat
                        where (!((a.MaHangSanXuat == 1) || (a.MaHangSanXuat == 2) || (a.MaHangSanXuat == 3) || (a.MaHangSanXuat == 4)) &&(a.MaLoai == MaLoai))
                        orderby a.GiaTien descending
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = d.TenHang,
                            TenLoai = c.TenLoai
                        });
            return dssp.ToPagedList(page, pagesize);
        }
        public IEnumerable<SanPhamViewModel> ListAllItemPageManuFac(int page, int pagesize, int mahang)
        {
            var dssp = (from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.LoaiSanPhams
                        on a.MaLoai equals c.MaLoai
                        join d in db.HangSanXuats
                        on a.MaHangSanXuat equals d.MaHangSanXuat
                        where a.MaHangSanXuat == mahang
                        orderby a.GiaTien descending
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = d.TenHang,
                            TenLoai = c.TenLoai
                        });
            return dssp.ToPagedList(page, pagesize);
        }
        public List<SanPhamBanPhimViewModel> ChiTietSanPhamBanPhim(string id)
        {
            var model = from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.HangSanXuats
                        on a.MaHangSanXuat equals c.MaHangSanXuat
                        join d in db.LoaiSanPhams
                        on a.MaLoai equals d.MaLoai
                        join e in db.ChiTietSanPhams
                        on a.MaChiTietSanPham equals e.MaChiTietSanPham
                        where a.MaSanPham == id
                        select new SanPhamBanPhimViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = c.TenHang,
                            TenLoai = d.TenLoai,
                            Switch = e.Switch,
                            LucNhan = e.LucNhan,
                            KetNoi = e.KetNoi,
                            SoLuongNut = e.SoLuongNut,
                            LED = e.LED
                        };
            return model.ToList();
        }
        public List<SanPhamTaiNgheViewModel> ChiTietSanPhamTaiNghe(string id)
        {
            var model = from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.HangSanXuats
                        on a.MaHangSanXuat equals c.MaHangSanXuat
                        join d in db.LoaiSanPhams
                        on a.MaLoai equals d.MaLoai
                        join e in db.ChiTietSanPhams
                        on a.MaChiTietSanPham equals e.MaChiTietSanPham
                        where a.MaSanPham == id
                        select new SanPhamTaiNgheViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = c.TenHang,
                            TenLoai = d.TenLoai,
                            DoDaiCuaDay = e.DoDaiCuaDay,
                            KieuTaiNghe = e.KieuTaiNghe,
                            KetNoi = e.KetNoi,
                            TroKhang = e.TroKhang,
                            LED = e.LED
                        };
            return model.ToList();
        }
        public List<SanPhamChuotViewModel> ChiTietSanPhamChuot(string id)
        {
            var model = from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.HangSanXuats
                        on a.MaHangSanXuat equals c.MaHangSanXuat
                        join d in db.LoaiSanPhams
                        on a.MaLoai equals d.MaLoai
                        join e in db.ChiTietSanPhams
                        on a.MaChiTietSanPham equals e.MaChiTietSanPham
                        where a.MaSanPham == id
                        select new SanPhamChuotViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = c.TenHang,
                            TenLoai = d.TenLoai,
                            SoLuongNut = e.SoLuongNut,
                            ThietKe = e.ThietKe,
                            KetNoi = e.KetNoi,
                            CamBien = e.CamBien,
                            MaxDPI = e.MaxDPI,
                            LED = e.LED
                        };
            return model.ToList();
        }
        public IEnumerable<SanPhamViewModel> TimKiemSanPham(int page, int pagesize,string tukhoatk)
        {
            var dssp = (from a in db.SanPhams
                        join b in db.HinhAnhSanPhams
                        on a.MaHinhAnh equals b.MaHinhAnh
                        join c in db.LoaiSanPhams
                        on a.MaLoai equals c.MaLoai
                        join d in db.HangSanXuats
                        on a.MaHangSanXuat equals d.MaHangSanXuat
                        where a.TenSanPham.Contains(tukhoatk)
                        orderby a.TenSanPham
                        select new SanPhamViewModel()
                        {
                            MaSanPham = a.MaSanPham,
                            TenSanPham = a.TenSanPham,
                            GiaTien = a.GiaTien,
                            MoTa = a.MoTa,
                            HinhAnh1 = b.HinhAnh1,
                            HinhAnh2 = b.HinhAnh2,
                            HinhAnh3 = b.HinhAnh3,
                            TenHang = d.TenHang,
                            TenLoai = c.TenLoai
                        }) ;
            return dssp.ToPagedList(page, pagesize);
        }
    }
}
