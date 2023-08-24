using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class HinhAnhDao
    {
        QuanLyBanGearDbContext db = null;
        public HinhAnhDao()
        {
            db = new QuanLyBanGearDbContext();
        }
        public HinhAnhSanPham ViewDetail(string id)
        {
            return db.HinhAnhSanPhams.Find(id);
        }
        public List<HinhAnhSanPham> ListAll()
        {
            return db.HinhAnhSanPhams.ToList();
        }
    }
}
