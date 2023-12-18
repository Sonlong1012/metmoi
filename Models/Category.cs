

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webbanhang_22011267.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string? TenDanhMuc  { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? MoTa { get; set; }

        public ICollection<Product>? Product { get; set; }
    }
}
