using System.Data;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Mappers
{
    static class UserMapper
    {
        public static User Map(IDataRecord record)
        {
            var user = new User
            {
                Id = (int)record["Id"],
                UserName = (string)record["Name"],
                LastName = (string)record["LastName"],
                Login = (string)record["Login"],
                Password = (string)record["Password"],
                Role = (string)record["Role"],
                Status = (string)record["Status"]
            };
            return user;
        }
    }
}
