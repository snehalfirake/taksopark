using System.Data.SqlClient;

namespace Taksopark.DAL
{
    public interface IAppConfigConnectionFactory
    {
        SqlConnection Create();
    }
}
