using System;
using System.Data.SqlClient;
using Taksopark.DAL.Repositories;

namespace Taksopark.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly SqlConnection _connection;

        public UnitOfWork(ISqlConnectionFactory configConnection)
        {
            _connection = configConnection.Create();
        }

        public UserRepository UserRepository
        {
            get
            {
                return new UserRepository(_connection);
            }
        }

        public CarRepository CarRepository
        {
            get
            {
                return new CarRepository(_connection);
            }
        }

        public CommentRepository CommentRepository
        {
            get
            {
                return new CommentRepository(_connection);
            }
        }

        public ImageRepository ImageRepository
        {
            get
            {
                return new ImageRepository(_connection);
            }
        }

        public RequestRepository RequestRepository
        {
            get
            {
                return new RequestRepository(_connection);
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
