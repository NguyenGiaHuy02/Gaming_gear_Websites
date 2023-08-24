using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class DonHangDao
    {
        QuanLyBanGearDbContext db = null;
        public DonHangDao()
        {
            db = new QuanLyBanGearDbContext();
        }
        public int Insert(DonHang donhang)
        {
            db.DonHangs.Add(donhang);
            db.SaveChanges();
            return donhang.MaDon;
        }
        public List<DonHang> ListAll()
        {
            return db.DonHangs.ToList();
        }
    }
}
