using System.Web;
using System.Web.Optimization;

namespace AuroraProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        //MY PROFILE UPDATE
                        "~/Scripts/app/services/updateMyProfileService.js",
                        "~/Scripts/app/controllers/updateMyProfileController.js",
                        //GIG
                        "~/Scripts/app/services/gigService.js",
                        "~/Scripts/app/controllers/gigController.js",                        
                        //INFLUENCER
                        "~/Scripts/app/services/influencerService.js",
                        "~/Scripts/app/controllers/influencerController.js",
                        //NOTIFICATIONS
                        "~/Scripts/app/services/notificationService.js",
                        "~/Scripts/app/controllers/notificationController.js",
                        //PURCHASE SELLING PACKAGE
                        "~/Scripts/app/services/purchaseService.js",
                        "~/Scripts/app/controllers/purchaseController.js",
                        //ORDER SELLING PACKAGE
                        "~/Scripts/app/services/orderService.js",
                        "~/Scripts/app/controllers/orderController.js",
                        //FORM INPUT CHECK FOR INFLUENCER FORM AND GIG FORM
                        "~/Scripts/app/controllers/formInputCheckController.js",
                        //SEARCH CONTROLLER
                        "~/Scripts/app/controllers/searchController.js",
                        //HOVER CONTROLLER
                        "~/Scripts/app/controllers/hoverIndustryController.js",
                        //HTML TAB CONTROLLER
                        "~/Scripts/app/controllers/htmlTabController.js",
                        //HTML MOUSE CAPTRUE CONTROLLER
                        "~/Scripts/app/controllers/mouseCaptureController.js",
                        //APP JS
                        "~/Scripts/app.app.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/bootbox.min.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/underscore.min.js",
                        "~/Scripts/moment.js"
));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/toastr.css",
                      "~/Content/animate.css"));
        }
    }
}
