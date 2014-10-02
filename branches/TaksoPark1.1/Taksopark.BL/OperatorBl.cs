using System;
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

            if ((oldRequest.Status == (int)RequestStatusEnum.Active && request.Status == (int)RequestStatusEnum.Closed)
                || (oldRequest.Status == (int)RequestStatusEnum.InProgress && request.Status == (int)RequestStatusEnum.Active)
                || (oldRequest.Status == (int)RequestStatusEnum.Rejected && request.Status == (int)RequestStatusEnum.Active)
                || (oldRequest.Status == (int)RequestStatusEnum.Rejected && request.Status == (int)RequestStatusEnum.InProgress)
                || (oldRequest.Status == (int)RequestStatusEnum.Rejected && request.Status == (int)RequestStatusEnum.Closed)
                || (oldRequest.Status == (int)RequestStatusEnum.Closed && request.Status == (int)RequestStatusEnum.Active)
                || (oldRequest.Status == (int)RequestStatusEnum.Closed && request.Status == (int)RequestStatusEnum.InProgress)
                || (oldRequest.Status == (int)RequestStatusEnum.Closed && request.Status == (int)RequestStatusEnum.Rejected))
            {
                throw new ArgumentException("Wrong parametrs for request update");
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
        public List<Driver> GetAllDriversByStatus(int status)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var drivers = uow.DriverRepository.GetAllDriversByStatus(status);
                return drivers.ToList();
            }
        }
        public List<Driver> GetAllDriversByDriverStatus(int driverStatus)
        {
            using (var uow = new UnitOfWork(_appConfigConnection))
            {
                var drivers = uow.DriverRepository.GetAllDriversByDriverStatus(driverStatus);
                return drivers.ToList();
            }
        }
    }
}
