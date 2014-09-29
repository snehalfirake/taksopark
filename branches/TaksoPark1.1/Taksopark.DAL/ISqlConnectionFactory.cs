using System.Data.SqlClient;

namespace Taksopark.DAL
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Create();
    }
}
