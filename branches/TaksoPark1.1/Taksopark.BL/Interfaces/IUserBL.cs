using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    public interface IUserBl
    {
        int CreateRequest(Request request);
        void UpdateRequest(Request request);
        void CreateComment(Comment comment);
        void CreateUser(User user);
        void UpdateUser(User user);
        List<Car> GetAllCars();
        List<Request> GetAllRequests();
        List<Request> GetAllRequestsByCreatorID(int creatorId);
        bool IsLoginBooked(string login);
        User GetUserByLoginAndPassword(string login, string password);
        User GetUserByLogin(string login);
        Request GetRequestById(int id);
    }
}
