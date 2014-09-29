using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taksopark.MVC.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Login can not be empty")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Password must be less than 30 characters")]
        public string Password { get; set; }
    }
}