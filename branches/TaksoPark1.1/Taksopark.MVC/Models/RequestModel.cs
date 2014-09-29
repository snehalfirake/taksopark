using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taksopark.MVC.Models
{
    public class RequestModel
    {
        public int RequestId { get; set; }
        public DateTime RequesTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string StartPoint { get; set; }
        public string FinishPoint { get; set; }
    }
}