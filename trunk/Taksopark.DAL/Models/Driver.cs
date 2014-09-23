using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksopark.DAL.Models
{
    public class Driver : User
    {
        public Car Car { get; set; }
    }
}
