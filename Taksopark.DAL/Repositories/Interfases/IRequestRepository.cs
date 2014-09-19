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
        void DeleteRequest(int requestId);
        Request GetRequestById(int id);
    }
}
