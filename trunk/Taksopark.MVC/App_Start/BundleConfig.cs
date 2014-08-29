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
            bundles.Add(new ScriptBundle("~/bundles/userinfo").Include(
                      "~/Scripts/app-scripts/userinfo-script.js"));
        }
    }
}