using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taksopark.DAL.Repositories
{
    class UserRepository: IUserRepository
    {
        private SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Update(Models.User user)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Users SET Name = @userName, 
                                      LastName = @lastName,
                                      Login = @login,
                                      Password = @password,
                                      Role = @role,
                                      Status = @status
                                      WHERE Id = @userId";
                command.Parameters.AddWithValue("userName", user.UserName);
                command.Parameters.AddWithValue("lastName", user.LastName);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("role", user.Role);
                command.Parameters.AddWithValue("status", user.Status);
                command.Parameters.AddWithValue("userId", user.Id);

            }
        }

        public void Create(Models.User user)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Users (Name, LastName, Login, Password, Role, Status) " +
                                      "VALUES(@userName, @lastName, @login, @password, @role, @status)";
                command.Parameters.AddWithValue("userName", user.UserName);
                command.Parameters.AddWithValue("lastName", user.LastName);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("role", user.Role);
                command.Parameters.AddWithValue("status", user.Status);
                command.Parameters.AddWithValue("userId", user.Id);
            }
        }

        public IEnumerable<Models.User> FindAllUsers()
        {
            using (var command = _connection.CreateCommand() )
            {
                command.CommandText = "SELECT * FROM Users";
                //return ToList()
            }
        }
    }
}
