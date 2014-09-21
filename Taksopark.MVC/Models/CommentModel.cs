using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taksopark.MVC.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        [Required]
        public string RequestPath { get; set; }
        public string CommentText { get; set; }
        public int RequestId { get; set; }
    }
}