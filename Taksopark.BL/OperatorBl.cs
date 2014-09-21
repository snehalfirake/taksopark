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

        //public OperatorBl()
        //{
        //    _appConfigConnection = new SqlConnectionFactory("Data Source=SQL5013.myASP.NET;Initial Catalog=DB_9B37A6_TaxiServiceDB;User Id=DB_9B37A6_TaxiServiceDB_admin;Password=12345678;");
        //}

        public List<Request> GetAllRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return uow.RequestRepository.GetAllRequests().ToList();
            }
        }

        public List<Request> GetActiveRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                    where request.Status == "Active"
                    select request).ToList();
            }
        }

        public List<Request> GetProgressRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                        where request.Status == "InProgress"
                        select request).ToList();
            }
        }

        public List<Request> GetClosedRequests()
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                return (from request in uow.RequestRepository.GetAllRequests()
                        where request.Status == "Closed"
                        select request).ToList();
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
                var userList = from user in uow.UserRepository.GetAllUsers()
                               where user.Role == "Driver"
                               select user;
                return userList.ToList();
            }
        }
    }
}
