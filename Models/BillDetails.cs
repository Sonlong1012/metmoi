using System.ComponentModel.DataAnnotations;

namespace Webbanhang_22011267.Models
{
    public class BillDetails
    {
        [Key]
        public int Id { get; set; }
        public int? HoaDonID { get; set; }
        public int? SanPhamID { get; set; }
        public int? Gia { get; set; }

        public int? SoLuong { get; set; }

        public int? TongTien { get; set; }

       
    }
}
