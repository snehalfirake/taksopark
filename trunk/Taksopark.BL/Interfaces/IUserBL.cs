using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.BL.Interfaces
{
    interface IUserBl
    {
        void CreateRequest(Request request);
        void CreateComment(Comment comment);
        void CreateUser(User user);
        List<Car> GetAllCars();
        bool IsLoginBooked(string login);
        User GetUserByLoginAndPassword(string login, string password);
    }
}
