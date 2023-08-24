using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class QuanLyBanGearDbContext : DbContext
    {
        public QuanLyBanGearDbContext()
            : base("name=QuanLyBanGear")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<HangSanXuat> HangSanXuats { get; set; }
        public virtual DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaSanPham)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.MaChiTietSanPham)
                .IsFixedLength();

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.TrongLuong)
                .HasPrecision(4, 3);

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.DoDaiCuaDay)
                .HasPrecision(4, 3);

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.LucNhan)
                .HasPrecision(4, 3);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangSanXuat>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.HangSanXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HinhAnhSanPham>()
                .Property(e => e.MaHinhAnh)
                .IsFixedLength();

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.MaLoai)
                .IsFixedLength();

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.LoaiSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.DienThoai)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MaQuyen)
                .IsFixedLength();

            modelBuilder.Entity<Quyen>()
                .Property(e => e.MaQuyen)
                .IsFixedLength();

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.NguoiDungs)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSanPham)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaHinhAnh)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLoai)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaChiTietSanPham)
                .IsFixedLength();

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
