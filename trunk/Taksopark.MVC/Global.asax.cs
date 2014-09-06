using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Taksopark.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    HttpContext oHttpContext;
        //    Exception oException;

        //    oHttpContext = HttpContext.Current;

        //    oException = oHttpContext.Server.GetLastError();

        //    if (oException is HttpException)
        //    {
        //        switch ((oException as HttpException).GetHttpCode())
        //        {
        //            //case 404:
        //            //    oHttpContext.Response.StatusCode = 404;
        //            //    oHttpContext.Response.StatusDescription = "Not Found";
        //            //    oHttpContext.Response.Charset = "windows-1251";
        //            //    oHttpContext.Server.Execute("~/Views/Home/Error404");
        //            //    oHttpContext.Server.ClearError();
        //            //    break;

        //            //case 500:
        //            //    oHttpContext.Response.StatusCode = 500;
        //            //    oHttpContext.Response.StatusDescription = "Internet server error";
        //            //    oHttpContext.Response.Charset = "windows-1251";
        //            //    oHttpContext.Server.Execute("~/Views/Home/Error500");
        //            //    oHttpContext.Server.ClearError();
        //            //    break;
        //        }
        //    }
        //}
    }
}
