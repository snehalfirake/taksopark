using System;
using System.Data.SqlClient;
using Taksopark.DAL.Repositories;

namespace Taksopark.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SqlConnection _connection;
        private readonly string _connectionString;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        private void CreateConnection()
        {
            if (_connectionString == null) return;
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void Dispose()
        {
            if (_connection == null)
            {
                return;
            }
            _connection.Close();
            _connection = null;
            GC.SuppressFinalize(this);
        }
        
        ~UnitOfWork()
        {
            if (_connection == null)
            {
                return;
            }
            _connection.Close();
            _connection = null;
        }
        public UserRepository UserRepository
        {
            get
            {
                if (_connection == null)
                {
                    CreateConnection();                    
                }
                return  new UserRepository(_connection);
            }
        }

        public CarRepository CarRepository
        {
            get
            {
                if (_connection == null)
                {
                    CreateConnection();
                }
                return new CarRepository(_connection);
            }
        }

        public CommentRepository CommentRepository
        {
            get
            {
                if (_connection == null)
                {
                    CreateConnection();
                }
                return new CommentRepository(_connection);
            }
        }

        public ImageRepository ImageRepository
        {
            get
            {
                if (_connection == null)
                {
                    CreateConnection();
                }
                return new ImageRepository(_connection);
            }
        }

        public RequestRepository RequestRepository
        {
            get
            {
                if (_connection == null)
                {
                    CreateConnection();
                }
                return new RequestRepository(_connection);
            }
        }

    }
}
