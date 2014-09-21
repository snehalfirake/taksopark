using Microsoft.Practices.Unity;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;

namespace Taksopark.BL
{
    public class BLContainerBootstraper
    {
        public static void RegisterTypes(IUnityContainer container, string connectionString)
        {
            container.RegisterType<ISqlConnectionFactory, SqlConnectionFactory>(new InjectionConstructor(connectionString));
            container.RegisterType<IAdminBl, AdminBl>();
            container.RegisterType<IUserBl, UserBl>();
            container.RegisterType<IOperatorBl, OperatorBl>();
        }
    }
}
