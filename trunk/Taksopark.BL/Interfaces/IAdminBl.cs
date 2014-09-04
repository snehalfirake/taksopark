using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    interface IAdminBl
    {
        List<User> GetAllOperators();
        List<User> GetAllClients();
        List<User> GetAllDrivers();
        void UpdateUser(User user);
        void CreateCar(Car car);
        void CreateUser(User user);

    }
}
