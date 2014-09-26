using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface IUserRepository
    {
        void Update(User user);
        void Create(User user);
        bool IsLoginBooked(string login);
        User GetUserByLogInAndPassword(string login, string password);
        User GetUserByLogIn(string login);
        bool IsLoginBookedByOtherId(string login, int id);
        IEnumerable<User> GetAllUsersByStatus(int status);
        IEnumerable<User> GetAllOperatorsByStatus(int status);
    }
}
