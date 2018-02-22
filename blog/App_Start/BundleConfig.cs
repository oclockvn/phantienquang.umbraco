using System.Web;
using System.Web.Optimization;

namespace blog
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-3.2.1.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            var js = new string[]
            {
                "~/Scripts/jquery-3.2.1.min.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/mdb.min.js",
                "~/Scripts/noframework.waypoints.min.js",
                "~/Scripts/timeago.min.js",
                "~/Scripts/timeago.locales.min.js",
                "~/Scripts/lazyload.min.js"
            };
            bundles.Add(new ScriptBundle("~/bundles/js").Include(js));

            var css = new string[]
            {
                "~/Content/fontawesome.min.css",
                "~/Content/fa-brands.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/mdb.min.css",
                "~/Content/lumx.css",
                "~/Content/styles/common.css",
                "~/Content/styles/style.css",
            };
            bundles.Add(new StyleBundle("~/bundles/css").Include(css));

#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}