using System.Web.Optimization;

namespace Taksopark.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Layout/my-css").Include("~/Content/Layout/style.css",
                                                                      "~/Content/Layout/login-style.css"));
            bundles.Add(new StyleBundle("~/Content/Layout/about").Include("~/Content/Layout/About.css"));
            bundles.Add(new StyleBundle("~/Content/Layout/error-style").Include("~/Content/Layout/error-style.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css",
                                                                      "~/Content/bootstrap-responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/userinfo").Include(
                      "~/Scripts/app-scripts/userinfo-script.js"));
            bundles.Add(new ScriptBundle("~/bundles/ready-script").Include("~/Scripts/app-scripts/ready.js", "~/Scripts/app-scripts/camera.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js", "~/Scripts/bootstrap.min.js"));
        }
    }
}