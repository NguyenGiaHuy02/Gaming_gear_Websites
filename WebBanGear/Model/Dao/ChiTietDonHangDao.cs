using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class ChiTietDonHangDao
    {
        QuanLyBanGearDbContext db = null;
        public ChiTietDonHangDao()
        {
            db = new QuanLyBanGearDbContext();
        }
        public bool Insert(ChiTietDonHang chiTietDonHang)
        {
            try
            {
                db.ChiTietDonHangs.Add(chiTietDonHang);
                db.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }
    }
}
