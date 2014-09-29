using System;
using System.Web.Configuration;
using Microsoft.Practices.Unity;
using Taksopark.BL;
using Taksopark.MVC.Controllers;
using Taksopark.MVC.Controllers.Home;

namespace Taksopark.MVC.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var conectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            BLContainerBootstraper.RegisterTypes(container, conectionString);
            container.RegisterType<HomeController>();
            container.RegisterType<AccountController>();
            container.RegisterType<ContactsController>();
            container.RegisterType<ErrorController>();
            container.RegisterType<UserProfileController>();
        }
    }
}