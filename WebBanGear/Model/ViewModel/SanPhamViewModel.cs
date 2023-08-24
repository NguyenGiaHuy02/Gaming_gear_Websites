using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Model.ViewModel
{
    public class SanPhamViewModel
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
    }
    
}
