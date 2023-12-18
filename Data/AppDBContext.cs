using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webbanhang_22011267.Models;

namespace Webbanhang_22011267.Data
{
    public class AppDBContext:IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<CartDetails > CartDetails { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<BillDetails> BillDetails { get; set; } = null!;
        public DbSet<Webbanhang_22011267.Models.Cart>? Cart { get; set; } = null!;
        public DbSet<Webbanhang_22011267.Models.Bill>? Bill { get; set; } = null!;
        public DbSet<Webbanhang_22011267.Models.Users>? User { get; set; } = null!;
      
    }
}
