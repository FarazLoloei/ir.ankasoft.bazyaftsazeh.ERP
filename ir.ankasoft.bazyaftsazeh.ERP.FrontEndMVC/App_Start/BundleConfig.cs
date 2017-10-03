using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // App Styles
            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Content/app/css/app-rtl.css"
            ));
            // Bootstrap Styles
            bundles.Add(new StyleBundle(Bundles.Styles.bootstrap_RTL).Include(
                "~/Content/app/css/bootstrap-rtl.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/simpleLineIcons").Include(
             "~/Vendor/simple-line-icons/css/simple-line-icons.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
                "~/content/font-awesome.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle(Bundles.Styles.bbcNassim).Include(
                "~/Vendor/bbcnassim/css/font-bbcnassim.min.css", new CssRewriteUrlTransform()

            ));

            bundles.Add(new StyleBundle(Bundles.Styles.iranSans).Include(
                "~/Content/IranSans/IranSans.css", new CssRewriteUrlTransform()
            //Links.Content.IranSans.IranSans_css, new CssRewriteUrlTransform()
            //"~/Vendor/bbcnassim/css/font-bbcnassim.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle(Bundles.Styles.roboto).Include(
                "~/Vendor/roboto/css/font-Roboto.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/animatecss").Include(
              "~/Vendor/animate.css/animate.min.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/whirl").Include(
              "~/Vendor/whirl/dist/whirl.css"
            ));
            bundles.Add(new StyleBundle("~/bundles/contextMenuCss").Include(
                "~/Content/jquery.contextMenu.min.css",
                "~/Content/jquery.contextMenu-overlay.css"
            //"~/Vendor/contextMenu/jquery.contextmenu.css",
            //"~/Vendor/contextMenu/jquery.contextmenu-overlay.css"
            ));
            bundles.Add(new StyleBundle(Bundles.Styles.sweetAlertCss).Include(
                "~/Vendor/sweetalert/dist/sweetalert.css",
                "~/Vendor/sweetalert/dist/sweetalert-overlay.css"
            ));
            bundles.Add(new StyleBundle(Bundles.Styles.siteCss).Include(
                "~/Content/site.css"
            ));

            bundles.Add(new StyleBundle(Bundles.Styles.Select2Css).Include(
                "~/Content/css/select2.css",
                "~/Content/css/select2-overlay.css"
            ));

            bundles.Add(new StyleBundle(Bundles.Styles.bootstrapPersianDatePickerCss).Include(
                "~/Content/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker.css",
                "~/Content/MdBootstrapPersianDateTimePicker/jquery.Bootstrap-PersianDateTimePicker-overlay.css"
            ));

            bundles.Add(new StyleBundle(Bundles.Styles.bootstrapDatePickerCss).Include(
                "~/Content/bootstrap-datetimepicker.css"
            //"~/Content/bootstrap-datetimepicker.min.css"
            ));

            bundles.Add(new StyleBundle(Bundles.Styles.tagsinputCss).Include(
                "~/Content/bootstrap-tagsinput.css"
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.Anka).Include(
               // App init
               Links.Bundles.Scripts.app.Assets.app_init_js,

               // Modules
               Links.Bundles.Scripts.app.modules.Assets.bootstrap_start_js,
               Links.Bundles.Scripts.app.modules.Assets.constants_js,
               Links.Bundles.Scripts.app.modules.Assets.fullscreen_js,
               //Links.Bundles.scripts.app.modules.Assets.localize_js, //For Localize panel
               Links.Bundles.Scripts.app.modules.Assets.navbar_search_js,
               Links.Bundles.Scripts.app.modules.Assets.notify_js,
               Links.Bundles.Scripts.app.modules.Assets.panel_tools_js,
               Links.Bundles.Scripts.app.modules.Assets.play_animation_js,
               Links.Bundles.Scripts.app.modules.Assets.sidebar_js,
               Links.Bundles.Scripts.app.modules.Assets.slimscroll_js,
               Links.Bundles.Scripts.app.modules.Assets.toggle_state_js,
               Links.Bundles.Scripts.app.modules.Assets.utils_js//,
                                                                //Links.Bundles.scripts.app.modules.Assets.select2_js
           ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.jquery).Include(
                //Links.scripts.jquery_2_1_4_js
                //"~/jquery-2.1.4.min.js"
                Links.Bundles.Scripts.Assets.jquery_2_2_4_min_js
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.modernizr).Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                Links.Bundles.Scripts.Assets.bootstrap_min_js
            ));

            bundles.Add(new ScriptBundle("~/bundles/storage").Include(
                "~/Vendor/jQuery-Storage-API/jquery.storageapi.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/matchMedia").Include(
                "~/Vendor/matchMedia/matchMedia.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEasing").Include(
              "~/Vendor/jquery.easing/js/jquery.easing.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/animo").Include(
             "~/Vendor/animo.js/animo.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
              "~/Vendor/slimscroll/jquery.slimscroll.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/screenfull").Include(
             "~/Vendor/screenfull/dist/screenfull.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/localize").Include(
              "~/Vendor/jquery-localize-i18n/dist/jquery.localize.js"
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.contextMenu).Include(
                //"~/Vendor/contextMenu/jquery.contextmenu.js"
                "~/Scripts/jquery.contextMenu.min.js"
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.sweetAlert).Include(
                "~/Vendor/sweetalert/dist/sweetalert.js"
            ));
            bundles.Add(new ScriptBundle(Bundles.Scripts.AnkaTools).Include(
                "~/Vendor/Anka/anka.tools.js"
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.Select2).Include(
                //Links.Bundles.Scripts.Assets.select2_full_min_js
                Links.Bundles.Scripts.Assets.select2_min_js
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.bootstrapPersianDatePicker).Include(
                Links.Bundles.Scripts.MdBootstrapPersianDateTimePicker.Assets.jalaali_js,
                Links.Bundles.Scripts.MdBootstrapPersianDateTimePicker.Assets.jquery_Bootstrap_PersianDateTimePicker_js
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.tagsinput).Include(
                Links.Bundles.Scripts.Assets.bootstrap_tagsinput_min_js
            ));

            bundles.Add(new ScriptBundle(Bundles.Scripts.bootstrapDatePicker).Include(
                Links.Bundles.Scripts.Assets.moment_min_js,
                Links.Bundles.Scripts.Assets.bootstrap_datetimepicker_min_js
            ));

        }
    }
}