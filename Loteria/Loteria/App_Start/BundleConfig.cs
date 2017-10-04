using System.Web.Optimization;

namespace Loteria
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/scripts").Include(
                        "~/Content/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/Css").Include(
                      "~/Content/Css/site.css"));
        }
    }
}
