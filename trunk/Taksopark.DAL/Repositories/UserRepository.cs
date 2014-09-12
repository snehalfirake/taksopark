using System.Collections.Generic;
using System.Data.SqlClient;
using Taksopark.DAL.Models;
using Taksopark.DAL.Repositories.Interfases;
using Taksopark.DAL.Repositories.Mappers;

namespace Taksopark.DAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Update User record
        /// </summary>
        /// <param name="user">User model</param>
        public void Update(User user)
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
                command.Parameters.AddWithValue("login", user.Login);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("role", user.Role);
                command.Parameters.AddWithValue("status", user.Status);
                command.Parameters.AddWithValue("userId", user.Id);
                command.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Create new user record
        /// </summary>
        /// <param name="user">User model</param>
        public void Create(User user)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Users (Name, LastName, Login, Password, Role, Status) " +
                                      "VALUES(@userName, @lastName, @login, @password, @role, @status)";
                command.Parameters.AddWithValue("userName", user.UserName);
                command.Parameters.AddWithValue("lastName", user.LastName);
                command.Parameters.AddWithValue("login", user.Login);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("role", user.Role);
                command.Parameters.AddWithValue("status", user.Status);
                //command.Parameters.AddWithValue("userId", user.Id);
                command.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// Get all user records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            using (var command = _connection.CreateCommand() )
            {
                command.CommandText = "SELECT * FROM Users";
                var userList = new List<User>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = UserMapper.Map(reader);
                        userList.Add(user);
                    }
                }
                return userList;
            }
        }

        /// <summary>
        /// Get users by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsersByRole(string role)
        {
            //_connection.Open();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Users WHERE Role = @role";
                command.Parameters.AddWithValue("role", role);
                var userList = new List<User>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = UserMapper.Map(reader);
                        userList.Add(user);
                    }
                }
                //_connection.Close();
                return userList;
            }
        }

        /// <summary>
        /// Delete user record from DB
        /// </summary>
        /// <param name="userId">User id in DB</param>
        public void DeleteUser(int userId)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Users WHERE ID = @userId";
                command.Parameters.AddWithValue("userId", userId);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Check is already user with the same login
        /// </summary>
        /// <param name="login">String login value</param>
        /// <returns></returns>
        public bool IsLoginBooked(string login)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Users";
                var user = new User();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = UserMapper.Map(reader);
                    }
                }
                if (user.Login == login)
                {
                    return true;
                }
            }
            return false;
        }


        public User GetUserByLogIn(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Users WHERE Id = @id";
                command.Parameters.AddWithValue("id", id);
                User findUser = new User();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = UserMapper.Map(reader);
                        findUser = user;
                    }
                }
                return findUser;
            }
        }
    }
}
