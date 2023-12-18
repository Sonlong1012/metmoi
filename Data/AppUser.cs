using Microsoft.AspNetCore.Identity;

namespace Webbanhang_22011267.Data
{
    public class AppUser: IdentityUser
    {
        public string? FristName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

    }
}
