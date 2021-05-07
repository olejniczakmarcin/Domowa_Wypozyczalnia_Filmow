using System.Web;
using System.Web.Optimization;

namespace KinoApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            "~/Content/themes/base/all.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqgrid").Include(
                "~/Scripts/i18n/grid.locale-pl.js", "~/Scripts/jquery.jqGrid.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/timepicker").Include(
                 "~/Scripts/jquery.timepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/jqGrid/css").Include(
                    "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/jquery.timepicker.min.css"));
        }
    }
}
