using System.ComponentModel.DataAnnotations;

namespace DotBlog.Models.ViewModels
{
    /// <summary>Fields for Register</summary>
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password aren't comparing!!!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}