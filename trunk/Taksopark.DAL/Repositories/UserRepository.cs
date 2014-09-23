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
            using (var command = new SqlCommand("UpdateUser", _connection))
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
            using (var command = new SqlCommand("CreateUser", _connection))
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
                command.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// Get all user records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            var userList = new List<User>();
            using (var command = new SqlCommand("GetAllUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
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
        /// Get users by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsersByRole(string role)
        {
            var userList = new List<User>();
            using (var command = new SqlCommand("GetUsersByRole", _connection))
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
        /// Delete user record from DB
        /// </summary>
        /// <param name="userId">User id in DB</param>
        public void DeleteUser(int userId)
        {
            using (var command = new SqlCommand("DeleteUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
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
            using (var command = new SqlCommand("IsLoginBooked", _connection))
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
            using (var command = new SqlCommand("GetUserById", _connection))
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
            using (var command = new SqlCommand("GetUserByLogInAndPassword", _connection))
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
            using (var command = new SqlCommand("GetUserByLogIn", _connection))
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
        /// Get drivers join cars
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetDriversJoinCarsInfo()
        {
            var userList = new List<List<string>>();
            using (var command = new SqlCommand("GetDriversJoinCarsInfo", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var driverList = new List<string>();
                        driverList.Add(reader["Name"].ToString());
                        driverList.Add(reader["LastName"].ToString());
                        driverList.Add(reader["Login"].ToString());
                        driverList.Add(reader["PhoneNumber"].ToString());
                        driverList.Add(reader["Email"].ToString());
                        driverList.Add(reader["Status"].ToString());
                        driverList.Add(reader["Brand"].ToString());
                        driverList.Add(reader["Year"].ToString());
                        userList.Add(driverList);
                    }
                }
            }
            return userList;
        }
    }
}
