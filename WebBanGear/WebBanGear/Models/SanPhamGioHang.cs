using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.ViewModel;
namespace WebBanGear.Models
{
    [Serializable]
    public class SanPhamGioHang
    {
        public SanPhamViewModel sanpham { get; set; }
        public int SoLuong { get; set; }

        public decimal TongGia { get; set; }
    }
}