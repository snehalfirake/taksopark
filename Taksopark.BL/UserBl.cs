using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class UserBl : IUserBl
    {
        private readonly ISqlConnectionFactory _appConfigConnection;

        public UserBl(ISqlConnectionFactory appConfigConnection)
        {
            _appConfigConnection = appConfigConnection;
        }
        public void CreateRequest(DAL.Models.Request request)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.RequestRepository.Create(request);
            }
        }

        public void UpdateRequest(Request request)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.RequestRepository.Update(request);
            }
        }

        public void CreateComment(DAL.Models.Comment comment)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.CommentRepository.Create(comment);
            }
        }

        public void CreateUser(DAL.Models.User user)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.UserRepository.Create(user);
            }
        }

        public System.Collections.Generic.List<DAL.Models.Car> GetAllCars()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.CarRepository.GetAllCars().ToList();
            }
        }

        public List<Request> GetAllRequestsByCreatorID(int creatorId)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetAllRequestsByCreatorId(creatorId).ToList();
            }
        }

        public bool IsLoginBooked(string login)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.UserRepository.IsLoginBooked(login);
            }
        }


        public DAL.Models.User GetUserByLoginAndPassword(string login, string password)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.UserRepository.GetUserByLogInAndPassword(login, password);
            }
        }


        public DAL.Models.User GetUserByLogin(string login)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.UserRepository.GetUserByLogIn(login);
            }
        }

        public Request GetRequestById(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetRequestById(id);
            }
        }


        public void UpdateUser(DAL.Models.User user)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.UserRepository.Update(user);
            }
        }


        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }
    }
}
