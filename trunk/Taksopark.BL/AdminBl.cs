using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class AdminBl : IAdminBl
    {
        public List<User> GetUserByRole(string role)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                var users = uow.UserRepository.GetUsersByRole(role);
                return users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                var user = uow.UserRepository.GetUserById(id);
                return user;
            }
        }
        public User GetUserByLogin(string login)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                var user = uow.UserRepository.GetUserByLogIn(login);
                return user;
            }
        }

        public bool IsLoginBooked(string login)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                var isBooked = uow.UserRepository.IsLoginBooked(login);
                return isBooked;
            }
        }

        public void UpdateUser(User user)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                uow.UserRepository.Update(user);
            }
        }

        public void CreateUser(User user)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                uow.UserRepository.Create(user);
            }
        }

        public void CreateCar(Car car)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                uow.CarRepository.Create(car);
            }
        }
    }
}
