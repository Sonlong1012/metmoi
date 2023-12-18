using System.ComponentModel.DataAnnotations;

namespace Webbanhang_22011267.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^(\+84|84|0)(3|5|7|8|9|1[2689])\d{8}$", ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }



        //[Display(Name = "Last Name")]
        //public string? Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

      
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }


    }

}

