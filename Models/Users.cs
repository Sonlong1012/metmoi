using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbanhang_22011267.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public int? DanhMucID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Ten { get; set; }

        public int? Gia { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? NgayNhap { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string? ThuongHieu { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string? MoTa { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string? Hinh { get; set; }

       
    }
}
