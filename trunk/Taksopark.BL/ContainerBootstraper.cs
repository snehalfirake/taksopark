using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Taksopark.BL.Interfaces;
using Taksopark.DAL;

namespace Taksopark.BL
{
    public class ContainerBootstraper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAppConfigConnectionFactory, AppConfigConnectionFactory>();
            container.RegisterType<IAdminBl, AdminBl>();
            container.RegisterType<IUserBl, UserBl>();
            container.RegisterType<IOperatorBl, OperatorBl>();
        }
    }
}
