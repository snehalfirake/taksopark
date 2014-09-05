using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    interface IAdminBl
    {
        List<User> GetUserByRole(string role);
        void UpdateUser(User user);
        void CreateCar(Car car);
        void CreateUser(User user);
    }
}
