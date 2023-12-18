using System.ComponentModel.DataAnnotations;

namespace Webbanhang_22011267.Models
{
    public class CartDetails
    {
        [Key]
        public int Id { get; set; }
        public int? GioHangID { get; set; }
        public int? SanPhamID { get; set; }
        public int? SoLuong { get; set; }

        public int? TongTien { get; set; }

      
    }
}
