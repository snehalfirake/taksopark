using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    interface IOperatorBl
    {
        List<Request> GetAllRequests();
        List<Request> GetActiveRequests();
        List<Request> GetProgressRequests();
        List<Request> GetClosedRequests();
        void UpdateRequest(Request request);
        List<User> GetAllDrivers();
    }
}
