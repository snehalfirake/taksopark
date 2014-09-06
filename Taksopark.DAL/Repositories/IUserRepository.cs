using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taksopark.DAL.Models;

namespace Taksopark.DAL.Repositories
{
    interface IUserRepository
    {
        void Update(User user);
        void Create(User user);
        IEnumerable<User> FindAllUsers();
    }
}
