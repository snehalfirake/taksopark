using System.Collections.Generic;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories.Interfases
{
    interface IUserRepository
    {
        void Update(User user);
        void Create(User user);
        IEnumerable<User> GetAllUsers();
        void DeleteUser(int userId);
        bool IsLoginBooked(string login);
        User GetUserByLogInAndPassword(string login, string password);
        User GetUserByLogIn(string login);
        bool IsLoginBookedByOtherId(string login, int id);
        IEnumerable<User> GetAllUsersByStatus(string status);
        IEnumerable<User> GetAllOperatorsByStatus(string status);
    }
}
