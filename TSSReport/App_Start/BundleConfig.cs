using System.Web;
using System.Web.Optimization;

namespace TSSReport
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/datatable/jquery.dataTables.min.js",
                      "~/Scripts/datatable/dataTables.bootstrap.min.js",
                      "~/Scripts/datatable/dataTables.responsive.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                      "~/Scripts/sb-admin-2.min.js",
                      "~/Scripts/metisMenu.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                      "~/Content/datatable/dataTables.bootstrap.css",
                      "~/Content/datatable/dataTables.responsive.css"));

            bundles.Add(new StyleBundle("~/Content/dashboard").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/sb-admin-2.min.css",
                     "~/Content/metisMenu.min.css",
                     "~/Content/portal.style.css",
                     "~/Content/font-awesome/css/font-awesome.min.css"));
        }
    }
}
