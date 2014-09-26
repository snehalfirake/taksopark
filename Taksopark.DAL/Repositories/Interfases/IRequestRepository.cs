using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface IRequestRepository
    {
        void Update(Request request);
        int Create(Request request);
        IEnumerable<Request> GetAllRequests();
        IEnumerable<Request> GetAllRequestsByCreatorId(int id); 
        Request GetRequestById(int id);
        IEnumerable<Request> GetAllRequestsByStatus(int status);
    }
}
