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
                        //FORM INPUT CHECK FOR INFLUENCER FORM AND GIG FORM
                        "~/Scripts/app/services/updateMyProfileService.js",
                        "~/Scripts/app/controllers/updateMyProfileController.js",
                        //DISABLE GIG
                        "~/Scripts/app/services/disableGigService.js",
                        "~/Scripts/app/controllers/disableGigController.js",
                        //FORM INPUT CHECK FOR INFLUENCER FORM AND GIG FORM
                        "~/Scripts/app/services/formInputCheckService.js",
                        "~/Scripts/app/controllers/formInputCheckController.js",
                        // FAVOURITE GIG
                        "~/Scripts/app/services/favouriteGigService.js",
                        "~/Scripts/app/controllers/favourtieGigController.js",
                        //FAVOURITE INFLUENCER
                        "~/Scripts/app/services/favouriteInfluencerService.js",
                        "~/Scripts/app/controllers/favouriteInfluencerController.js",
                        //GET NOTIFICATIONS
                        "~/Scripts/app/services/notificationService.js",
                        "~/Scripts/app/controllers/notificationController.js",
                        //READ NOTIFICATION
                        "~/Scripts/app/services/readNotificationService.js",
                        "~/Scripts/app/controllers/readNotificationController.js",
                        //DELETE NOTIFICATION
                        "~/Scripts/app/services/deleteNotificationService.js",
                        "~/Scripts/app/controllers/deleteNotificationController.js",
                        //PURCHASE PACKAGE SERVICE
                        "~/Scripts/app/services/purchaseService.js",
                        //PURCHASE BASIC PACKAGE
                        "~/Scripts/app/controllers/purchaseBasicController.js",
                        //PURCHASE ADVANCED PACKAGE
                        "~/Scripts/app/controllers/purchaseAdvancedController.js",
                        //PURCHASE PREMIUM PACKAGE
                        "~/Scripts/app/controllers/purchasePremiumController.js",
                        //SEARCH CONTROLLER
                        "~/Scripts/app/controllers/searchController.js",
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
