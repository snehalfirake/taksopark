using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class AdminBl : IAdminBl
    {
        private readonly ISqlConnectionFactory _appConfigConnection;

        public AdminBl(ISqlConnectionFactory appConfigConnection)
        {
            _appConfigConnection = appConfigConnection;
        }

        public List<User> GetUserByRole(string role)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var users = uow.UserRepository.GetUsersByRole(role);
                return users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var user = uow.UserRepository.GetUserById(id);
                return user;
            }
        }
        public User GetUserByLogin(string login)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var user = uow.UserRepository.GetUserByLogIn(login);
                return user;
            }
        }

        public bool IsLoginBooked(string login)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var isBooked = uow.UserRepository.IsLoginBooked(login);
                return isBooked;
            }
        }

        public void UpdateUser(User user)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.UserRepository.Update(user);
            }
        }

        public void CreateUser(User user)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.UserRepository.Create(user);
            }
        }

        public void CreateCar(Car car)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.CarRepository.Create(car);
            }
        }

        public Car GetCarById(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var car = uow.CarRepository.GetCarById(id);
                return car;
            }
        }

        public void UpdateCar(Car car)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.CarRepository.Update(car);
            }
        }

        public bool IsCarIdBooked(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var isBooked = uow.CarRepository.IsCarIdBooked(id);
                return isBooked;
            }
        }

        public List<Car> GetAllCars()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var cars = uow.CarRepository.GetAllCars();
                return cars.ToList();
            }
        }
    }
}
