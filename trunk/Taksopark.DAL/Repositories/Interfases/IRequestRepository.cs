using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface IRequestRepository
    {
        void Update(Request request);
        void Create(Request request);
        IEnumerable<Request> GetAllRequests();
        IEnumerable<Request> GetAllRequestsByCreatorId(int id); 
        Request GetRequestById(int id);
        IEnumerable<Request> GetAllRequestsByState(int state);
        IEnumerable<Request> GetAllRequestsByStatus(int status);
    }
}
