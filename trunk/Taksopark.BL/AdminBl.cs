using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    class AdminBl : IAdminBl
    {
        private readonly string _connectionString;

        public AdminBl(string connnectionString)
        {
            _connectionString = connnectionString;
        }

        public List<User> GetUserByRole(string role)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                var users = uow.UserRepository.GetUsersByRole(role);
                return users.ToList();
            }
        }

        public void UpdateUser(User user)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.UserRepository.Update(user);
            }
        }

        public void CreateUser(User user)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.UserRepository.Create(user);
            }
        }

        public void CreateCar(Car car)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.CarRepository.Create(car);
            }
        }
    }
}
