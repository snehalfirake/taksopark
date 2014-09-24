using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class OperatorBl : IOperatorBl
    {
        private readonly ISqlConnectionFactory _appConfigConnection;

        public OperatorBl(ISqlConnectionFactory appConfigConnection)
        {
            _appConfigConnection = appConfigConnection;
        }

        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }


        public void UpdateRequest(Request request)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                uow.RequestRepository.Update(request);
            }
        }

        public List<User> GetAllDrivers()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var userList = uow.UserRepository.GetUsersByRole("Driver");
                return userList.ToList();
            }
        }


        public Request GetRequestById(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var request = uow.RequestRepository.GetRequestById(id);
                return request;
            }
        }

        public List<Request> GetRequestsByState(string state)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var requestList = uow.RequestRepository.GetAllRequestsByState(state);
                return requestList.ToList();
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

        public List<Request> GetAllRequestsByStatus(string status)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var requestList = uow.RequestRepository.GetAllRequestsByStatus(status);
                return requestList.ToList();
            }
        }
    }
}
