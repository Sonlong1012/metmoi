using System.ComponentModel.DataAnnotations;

namespace Webbanhang_22011267.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int? NguoiDungId { get; set; }

        public ICollection<CartDetails>CartDetails { get; set; }
    }
}
