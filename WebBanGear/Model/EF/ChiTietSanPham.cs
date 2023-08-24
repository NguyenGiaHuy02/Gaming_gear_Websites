namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        public string MaChiTietSanPham { get; set; }

        [StringLength(100)]
        public string MauSac { get; set; }

        public int? BaoHanh { get; set; }

        public decimal? TrongLuong { get; set; }

        [StringLength(30)]
        public string KichThuoc { get; set; }

        public decimal? DoDaiCuaDay { get; set; }

        [StringLength(100)]
        public string Switch { get; set; }

        public decimal? LucNhan { get; set; }

        [StringLength(250)]
        public string KetNoi { get; set; }

        public int? SoLuongNut { get; set; }

        [Required]
        [StringLength(10)]
        public string LED { get; set; }

        [StringLength(50)]
        public string LoaiChuot { get; set; }

        [StringLength(50)]
        public string ThietKe { get; set; }

        [StringLength(250)]
        public string CamBien { get; set; }

        public int? MaxDPI { get; set; }

        [StringLength(100)]
        public string KieuTaiNghe { get; set; }

        [StringLength(100)]
        public string TroKhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
