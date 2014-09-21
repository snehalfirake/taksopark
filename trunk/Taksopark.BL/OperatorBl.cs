using System.Collections.Generic;
using System.Linq;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;
using Taksopark.DAL.Models;

namespace Taksopark.BL
{
    public class OperatorBl : IOperatorBl
    {
        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }

        public List<Request> GetActiveRequests()
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                    where request.Status == "Active"
                    select request).ToList();
            }
        }

        public List<Request> GetProgressRequests()
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                        where request.Status == "InProgress"
                        select request).ToList();
            }
        }

        public List<Request> GetClosedRequests()
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                        where request.Status == "Closed"
                        select request).ToList();
            }
        }

        public void UpdateRequest(Request request)
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                uow.RequestRepository.Update(request);
            }
        }

        public List<User> GetAllDrivers()
        {
            using (var uow = new UnitOfWork(new AppConfigConnectionFactory()))
            {
                var userList = from user in uow.UserRepository.GetAllUsers()
                               where user.Role == "Driver"
                               select user;
                return userList.ToList();
            }
        }
    }
}
