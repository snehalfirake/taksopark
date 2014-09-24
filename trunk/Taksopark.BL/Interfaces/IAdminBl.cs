using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    public interface IAdminBl
    {
        List<User> GetUserByRole(string role);
        void UpdateUser(User user);
        void CreateCar(Car car);
        void CreateUser(User user);
        User GetUserById(int id);
        bool IsLoginBooked(string login);
        User GetUserByLogin(string login);
        Car GetCarById(int id);
        bool IsCarIdBooked(int id);
        void UpdateCar(Car car);
        List<Car> GetAllCars();
        List<Driver> GetAllDrivers();
        List<Driver> GetAllDriversByStatus(string status);
        bool IsLoginBookedByOtherId(string login, int id);
        List<User> GetAllUsersByStatus(string status);
        List<User> GetAllOperatorsByStatus(string status);
    }
}
