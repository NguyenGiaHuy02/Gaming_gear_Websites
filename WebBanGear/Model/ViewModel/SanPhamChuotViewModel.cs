using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.ViewModel
{
    public class SanPhamChuotViewModel
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal GiaTien { get; set; }
        public string MoTa { get; set; }
        public byte[] HinhAnh1 { get; set; }
        public byte[] HinhAnh2 { get; set; }
        public byte[] HinhAnh3 { get; set; }
        public string TenLoai { get; set; }
        public string TenHang { get; set; }
        public string KetNoi { get; set; }
        public int? SoLuongNut { get; set; }
        public string LED { get; set; }
        public string ThietKe { get; set; }
        public string CamBien { get; set; }
        public int? MaxDPI { get; set; }
    }
}
