using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class UserBl : IUserBl
    {
        private readonly string _connectionString;

        public UserBl(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateRequest(DAL.Models.Request request)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.RequestRepository.Create(request);
            }
        }

        public void CreateComment(DAL.Models.Comment comment)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.CommentRepository.Create(comment);
            }
        }

        public void CreateUser(DAL.Models.User user)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.UserRepository.Create(user);
            }
        }

        public System.Collections.Generic.List<DAL.Models.Car> GetAllCars()
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                return uow.CarRepository.GetAllCars().ToList();
            }
        }

        public List<Request> GetAllRequestsByCreatorID(int creatorId)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                return uow.RequestRepository.GetAllRequestsByCreatorId(creatorId).ToList();
            }
        }

        public bool IsLoginBooked(string login)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                return uow.UserRepository.IsLoginBooked(login);
            }
        }


        public DAL.Models.User GetUserByLoginAndPassword(string login, string password)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                return uow.UserRepository.GetUserByLogInAndPassword(login, password);
            }
        }


        public DAL.Models.User GetUserByLogin(string login)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                return uow.UserRepository.GetUserByLogIn(login);
            }
        }


        public void UpdateUser(DAL.Models.User user)
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                uow.UserRepository.Update(user);
            }
        }


        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(_connectionString))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }
    }
}
