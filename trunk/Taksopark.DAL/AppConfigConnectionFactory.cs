using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Taksopark.DAL
{
    public class AppConfigConnectionFactory : IAppConfigConnectionFactory
    {
        private readonly string _connectionString;
        private const string ConnectionName = "ConnectionString";

        public AppConfigConnectionFactory()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
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
