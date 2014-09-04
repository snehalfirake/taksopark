using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    class AdminBl : IAdminBl
    {
        private const string ConnectionString = "conn";
        
        public List<User> GetAllOperators()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return (from user in uow.UserRepository.GetAllUsers()
                    where user.Role == "Operator"
                    select user).ToList();
            }
        }

        public List<User> GetAllClients()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return (from user in uow.UserRepository.GetAllUsers()
                        where user.Role == "Client"
                        select user).ToList();
            }
        }

        public List<User> GetAllDrivers()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return (from user in uow.UserRepository.GetAllUsers()
                        where user.Role == "Driver"
                        select user).ToList();
            }
        }

        public void UpdateUser(User user)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.UserRepository.Update(user);
            }
        }

        public void CreateUser(User user)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.UserRepository.Create(user);
            }
        }

        public void CreateCar(Car car)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.CarRepository.Create(car);
            }
        }
    }
}
