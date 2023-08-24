namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSanPham { get; set; }

        public decimal GiaTien { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public int MaHangSanXuat { get; set; }

        [StringLength(10)]
        public string MaHinhAnh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; }

        [StringLength(10)]
        public string MaChiTietSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }

        public virtual HangSanXuat HangSanXuat { get; set; }

        public virtual HinhAnhSanPham HinhAnhSanPham { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
