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

        public string DriverInfo
        {
            get
            {
                return string.Format("{0} {1} +{2} ({3})",this.UserName,this.LastName,this.PhoneNumber,this.Car.CarBrand);
            }
        }
    }
}
