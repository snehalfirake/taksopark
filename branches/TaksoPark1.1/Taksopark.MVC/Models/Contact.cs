using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taksopark.MVC.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Name can not be empty")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                                ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Email must be less than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message can not be empty")]
        [StringLength(3500, ErrorMessage = "Message than must be less 3500 characters")]
        public string Message { get; set; }
    }
}