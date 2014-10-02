using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Microsoft.Practices.Unity;
using Taksopark.BL.Interfaces;
using Taksopark.DAL.Enums;
using Unity.WebForms;

namespace Taksopark.WebForms.WebForms
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                

                var userBl = HttpContext.Current.Application.GetContainer().Resolve<IUserBl>();
                var login = Request["txtUserName"];
                var password = Request["txtUserPass"];
                var user = userBl.GetUserByLoginAndPassword(login, password);
                if (user.UserName != null)
                {
                    if (user.Role == (int) RolesEnum.Operator || user.Role == (int) RolesEnum.Admin)
                    {
                        FormsAuthentication.SetAuthCookie(user.Login, false);
                        IPrincipal principal = HttpContext.Current.User;
                        var userName = principal.Identity.Name;
                        IIdentity identity = new GenericIdentity(userName);
                        var role = user.Role;
                        string[] roles = new[] {role.ToString()};
                        HttpContext.Current.User = new GenericPrincipal(identity, roles);
                        var redirectUrl = FormsAuthentication.GetRedirectUrl(userName, false);
                        if (redirectUrl == "/default.aspx")
                        {
                            if (user.Role == (int)RolesEnum.Operator)
                            {
                                Response.Redirect("Order.aspx");
                            }
                            else if (user.Role == (int)RolesEnum.Admin)
                            {
                                Response.Redirect("Users.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect(FormsAuthentication.GetRedirectUrl(userName, true));
                        }
                     
                    }
                }
                else
                {
                    CustomValidator1.IsValid = false;
                }
            }
        }
    }
}