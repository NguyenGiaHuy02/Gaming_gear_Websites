using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class UserDao
    {
        QuanLyBanGearDbContext db = null;
        public UserDao()
        {
            db = new QuanLyBanGearDbContext();
        }

        public long Insert(NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.MaNguoiDung;
        }
        public List<NguoiDung> ListAll()
        {
            return db.NguoiDungs.ToList();
        }
        public NguoiDung GetbyMaQuyen(string email)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.Email == email);
        }
        public int Login(string email, string matKhau)
        {
            var result = db.NguoiDungs.SingleOrDefault(x => x.Email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.MatKhau == matKhau)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        public bool CheckEmail(string email)
        {
            return db.NguoiDungs.Count(x => x.Email == email) > 0;
        }
    }
}
