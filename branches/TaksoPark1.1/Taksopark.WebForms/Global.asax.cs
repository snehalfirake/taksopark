using System;
using System.Security.Principal;
using System.Web;
using Microsoft.Practices.Unity;
using Taksopark.BL;
using Taksopark.BL.Interfaces;
using Unity.WebForms;

namespace Taksopark.WebForms
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal principal = HttpContext.Current.User;
            if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                var userName = principal.Identity.Name;
                IIdentity identity = new GenericIdentity(userName);
                var adminBl = HttpContext.Current.Application.GetContainer().Resolve<IAdminBl>();
                var role = adminBl.GetUserByLogin(userName).Role.ToString();
                string[] roles = new[] {role};
                HttpContext.Current.User = new GenericPrincipal(identity, roles);
            }

        }
    }
}