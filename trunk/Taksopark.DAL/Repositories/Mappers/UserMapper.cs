using System.Data;
using System.Data.SqlClient;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class UserMapper
    {
        public static User Map(SqlDataReader record)
        {
            var user = new User
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
                DriverStaus = record.IsDBNull(record.GetOrdinal("DriverStatus")) == false
               ? (int?)record["DriverStatus"]
               : default(int?)
            };
            return user;
        }
    }
}
