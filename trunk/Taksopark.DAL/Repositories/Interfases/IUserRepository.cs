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
        User GetUserByLogIn(string login, string password);
    }
}
