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
        [Required(ErrorMessage = "Login Required:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string Password { get; set; }
    }
}