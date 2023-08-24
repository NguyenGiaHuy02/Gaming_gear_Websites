using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class LoaiSanPhamDao
    {
        QuanLyBanGearDbContext db = null;
        public LoaiSanPhamDao()
        {
            db = new QuanLyBanGearDbContext();
        }
        public List<LoaiSanPham> ListAll()
        {
            return db.LoaiSanPhams.ToList();
        }
    }
}
