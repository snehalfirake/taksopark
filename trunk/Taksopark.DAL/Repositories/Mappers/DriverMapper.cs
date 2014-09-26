using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class DriverMapper
    {
        public static Driver Map(SqlDataReader record)
        {
            var driver = new Driver
            {
                Id = (int)record["Id"],
                UserName = (string)record["Name"],
                LastName = (string)record["LastName"],
                Login = (string)record["Login"],
                PhoneNumber = (string)record["PhoneNumber"],
                Email = (string)record["Email"],
                Password = (string)record["Password"],
                Role = (int)record["Role"],
                Status = (int)record["Status"],
                Car = new Car
                {
                    Id = (int)record["Id"],
                    CarBrand = (string)record["Brand"],
                    CarYear = (string)record["Year"],
                    StartWorkTime = (DateTime)record["StartWorkTime"],
                    FinishWorkTime = (DateTime)record["FinishWorkTime"],
                    Latitude = (string)record["Latitude"],
                    Longitude = (string)record["Longitude"]
                }
            };
            return driver;
        }
    }
}
