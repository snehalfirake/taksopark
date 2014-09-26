using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Enums;
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
            var oldRequest = this.GetRequestById(request.Id);
            if ((oldRequest.Status == 2 && request.Status == 8) || (oldRequest.Status == 4 && request.Status == 2)
                || (oldRequest.Status == 32 && request.Status == 2) || (oldRequest.Status == 32 && request.Status == 4)
                || (oldRequest.Status == 32 && request.Status == 8) || (oldRequest.Status == 8 && request.Status == 2)
                || (oldRequest.Status == 8 && request.Status == 8) || (oldRequest.Status == 8 && request.Status == 4)
                || (oldRequest.Status == 8 && request.Status == 32))
            {
                throw new SqlTypeException("Wrong parametrs for request update");
            }
            using (var uow = new UnitOfWork(_appConfigConnection)){
               
                uow.RequestRepository.Update(request);
            }
        }

        public List<User> GetAllDrivers()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var userList = uow.UserRepository.GetUsersByRole((int) RolesEnum.Driver);
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

        public User GetUserById(int id)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var user = uow.UserRepository.GetUserById(id);
                return user;
            }
        }

        public List<Request> GetAllRequestsByStatus(int status)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var requestList = uow.RequestRepository.GetAllRequestsByStatus(status);
                return requestList.ToList();
            }
        }
    }
}
