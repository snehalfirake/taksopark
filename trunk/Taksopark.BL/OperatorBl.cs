using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    class OperatorBl : IOperatorBl
    {
        private const string ConnectionString = "conn";

        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }

        public List<Request> GetActiveRequests()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                    where request.Status == "Active"
                    select request).ToList();
            }
        }

        public List<Request> GetProgressRequests()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                        where request.Status == "InProgress"
                        select request).ToList();
            }
        }

        public List<Request> GetClosedRequests()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                        where request.Status == "Closed"
                        select request).ToList();
            }
        }

        public void UpdateRequest(Request request)
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                uow.RequestRepository.Update(request);
            }
        }

        public List<User> GetAllDrivers()
        {
            using (var uow = new UnitOfWork(ConnectionString))
            {
                var userList = from user in uow.UserRepository.GetAllUsers()
                               where user.Role == "Driver"
                               select user;
                return userList.ToList();
            }
        }
    }
}
