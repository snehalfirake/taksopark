using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Taksopark.DAL
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Create()
        {
            var connection = new SqlConnection(_connectionString);
            if (connection == null)
            {
                throw new ConfigurationErrorsException("Failed to create connection using provided connection name");
            }
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw new DataException("Failed to connect to DB");
            }
            return connection;
        }
    }
}
