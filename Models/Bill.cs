using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbanhang_22011267.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        public DateTime? NgayMua { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string? DiaChiGH { get; set; }


        [Column(TypeName = "nchar(200)")]
        public string? DienThoaiGH { get; set; }

        public int? NguoiDungID { get; set; }

        public int? TrangThai { get; set; }

        public DateTime? NgayNhan { get; set; }

        public ICollection<BillDetails> BillDetails { get; set; }
    }
}
