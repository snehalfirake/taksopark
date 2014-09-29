using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Taksopark.MVC.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "First Name Required:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last Name Required:")]
        [DisplayName("Last Name:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login Required:")]
        [DisplayName("Login:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email Required:")]
        [DisplayName("Email:")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                                ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm not matched.")]
        [Display(Name = "Confirm password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone Number Required:")]
        [DisplayName("Phone Number:")]
        [StringLength(13, ErrorMessage = "13 Characters allowed")]
        public string PhoneNumber { get; set; } 
    }
}