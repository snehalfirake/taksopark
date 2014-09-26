using System;
using System.Collections.Generic;
using System.Data;
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
            using (var command = new SqlCommand("sp_UpdateUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Status", user.Status);
                if (user.DriverStatus == null)
                {
                    command.Parameters.AddWithValue("@DriverStatus", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DriverStatus", user.DriverStatus);

                }
                command.Parameters.AddWithValue("@UserId", user.Id);
                command.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Create new user record
        /// </summary>
        /// <param name="user">User model</param>
        public void Create(User user)
        {
            using (var command = new SqlCommand("sp_CreateUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Status", user.Status);
                if (user.DriverStatus == null)
                {
                    command.Parameters.AddWithValue("@DriverStatus", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DriverStatus", user.DriverStatus);
                  
                }
                command.ExecuteNonQuery();
            }
        }
        

        /// <summary>
        /// Get users by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsersByRole(int role)
        {
            var userList = new List<User>();
            using (var command = new SqlCommand("sp_GetUsersByRole", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Role", role);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = UserMapper.Map(reader);
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }


        /// <summary>
        /// Check is already user with the same login
        /// </summary>
        /// <param name="login">String login value</param>
        /// <returns></returns>
        public bool IsLoginBooked(string login)
        {
            using (var command = new SqlCommand("sp_IsLoginBooked", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", login);
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

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            using (var command = new SqlCommand("sp_GetUserById", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                var findUser = new User();
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


        public User GetUserByLogInAndPassword(string login, string password)
        {
            using (var command = new SqlCommand("sp_GetUserByLogInAndPassword", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                var user = new User();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = UserMapper.Map(reader);
                    }
                }
                return user;
            }
        }

        public User GetUserByLogIn(string login)
        {
            using (var command = new SqlCommand("sp_GetUserByLogIn", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", login);
                var user = new User();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = UserMapper.Map(reader);
                    }
                }
                return user;
            }
        }


        /// <summary>
        /// Check is already user with the same login, but other id
        /// </summary>
        /// <param name="login">String login value</param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsLoginBookedByOtherId(string login, int id)
        {
            using (var command = new SqlCommand("sp_IsLoginBookedByOtherId", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@ID", id);
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

        public IEnumerable<User> GetAllUsersByStatus(int status)
        {
            var userList = new List<User>();
            using (var command = new SqlCommand("sp_GetAllUsersByStatus", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Status", status);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = UserMapper.Map(reader);
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }

        public IEnumerable<User> GetAllOperatorsByStatus(int status)
        {
            var operatorList = new List<User>();
            using (var command = new SqlCommand("sp_GetAllOperatorsByStatus", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Status", status);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = UserMapper.Map(reader);
                        operatorList.Add(user);
                    }
                }
            }
            return operatorList;
        }
    }
}
