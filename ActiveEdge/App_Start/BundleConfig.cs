using System.Web.Optimization;

namespace ActiveEdge
{
    public static class Bundles
    {
        public static class Css
        {
            public const string Summernote = "~/bundles/summernotestyles";
            public const string DatePicker = "~/bundles/styles/datepicker";
            public const string ICheck = "~/bundles/styles/icheck";
            public const string WizardSteps = "~/bundles/styles/wizardSteps";
            public const string NoUiSlider = "~/bundles/styles/nouislider";
            public const string Taggle = "~/bundles/styles/taggle";
        }

        public static class Scripts
        {
            public const string ActiveEdge = "~/bundles/scripts/activeedge";
            public const string Jquery = "~/bundles/scripts/jquery";
            public const string JqueryValidation = "~/bundles/scripts/jqueryval";
            public const string Bootstrap = "~/bundles/scripts/bootstrap";
            public const string Inspinia = "~/bundles/scripts/inspinia";
            public const string DatePicker = "~/bundles/scripts/dataPicker";
            public const string MetsiMenu = "~/bundles/scripts/metsimenu";
            public const string SlimScroll = "~/bundles/scripts/slimscroll";
            public const string Pace = "~/bundles/scripts/pace";
            public const string ICheck = "~/bundles/scripts/icheck";
            public const string WizardSteps = "~/bundles/scripts/wizardSteps";
            public const string NoUiSlider = "~/bundles/scripts/nouislider";
            public const string Taggle = "~/bundles/scripts/taggle";

            public static class Session
            {
                public const string Create = "~/bundles/scripts/session/create";
                public const string Edit = "~/bundles/scripts/session/edit";
                public const string Plan = "~/bundles/scripts/session/plan";
                public const string Details = "~/bundles/scripts/session/details";
            }

            public static class Client
            {
                public const string Create = "~/bundles/scripts/client/create";
                public const string Edit = "~/bundles/scripts/client/edit";
            }

            public static class Organization
            {
                public const string Create = "~/bundles/scripts/organizaton/create";
            }
        }
    }

    public class BundleConfig
    {
        private static BundleCollection _bundles;

        public static void RegisterBundles(BundleCollection bundles)
        {
            _bundles = bundles;

            RegisterScripts(Bundles.Scripts.ActiveEdge, "~/Scripts/site/activeedge.js",
                "~/Scripts/typeahead.bundle.min.js", "~/Scripts/bloodhound.min.js",
                "~/Scripts/summernote/summernote.min.js");
            RegisterScripts(Bundles.Scripts.Client.Create, "~/Scripts/site/client/Create.js");
            RegisterScripts(Bundles.Scripts.Client.Edit, "~/Scripts/site/client/edit.js");

            RegisterScripts(Bundles.Scripts.Session.Create, "~/Scripts/site/session/create.js", "~/Scripts/site/session/drawing.js");
            RegisterScripts(Bundles.Scripts.Session.Edit, "~/Scripts/site/session/edit.js", "~/Scripts/site/session/drawing.js");
            RegisterScripts(Bundles.Scripts.Session.Plan, "~/Scripts/site/session/plan.js");
            RegisterScripts(Bundles.Scripts.Session.Details, "~/Scripts/site/session/details.js",
                "~/Scripts/site/session/drawing.js");

            RegisterScripts(Bundles.Scripts.Organization.Create, "~/Scripts/site/organization/create.js");

            // Vendor scripts
            RegisterScripts(Bundles.Scripts.Jquery, "~/Scripts/jquery-2.1.1.min.js");
            RegisterScripts(Bundles.Scripts.JqueryValidation, "~/Scripts/jquery.validate.min.js");
            RegisterScripts(Bundles.Scripts.Bootstrap, "~/Scripts/bootstrap.min.js");
            RegisterScripts(Bundles.Scripts.Inspinia, "~/Scripts/app/inspinia.js");
            RegisterScripts(Bundles.Scripts.DatePicker, "~/Scripts/plugins/datapicker/bootstrap-datepicker.js");
            RegisterScripts(Bundles.Scripts.MetsiMenu, "~/Scripts/plugins/metisMenu/metisMenu.min.js");
            RegisterScripts(Bundles.Scripts.SlimScroll, "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js");
            RegisterScripts(Bundles.Scripts.Pace, "~/Scripts/plugins/pace/pace.min.js");
            RegisterScripts(Bundles.Scripts.ICheck, "~/Scripts/plugins/iCheck/icheck.min.js",
                "~/Scripts/site/icheckwireup.js");
            RegisterScripts(Bundles.Scripts.WizardSteps, "~/Scripts/plugins/steps/jquery.steps.min.js");
            RegisterScripts(Bundles.Scripts.NoUiSlider, "~/Scripts/plugins/nouslider/jquery.nouislider.min.js");
            RegisterScripts(Bundles.Scripts.Taggle, "~/Scripts/plugins/taggle-js/js/taggle.min.js");


            // *****************************************************************************************************************************
            // CSS
            //******************************************************************************************************************************
            RegisterCss(Bundles.Css.DatePicker, "~/Content/plugins/datapicker/datepicker3.css");
            RegisterCss(Bundles.Css.ICheck, "~/Content/plugins/iCheck/custom.css");
            RegisterCss(Bundles.Css.WizardSteps, "~/Content/plugins/steps/jquery.steps.css");
            RegisterCss(Bundles.Css.NoUiSlider, "~/Content/plugins/nouslider/jquery.nouislider.css");
            RegisterCss(Bundles.Css.Taggle, "~/Scripts/plugins/taggle-js/css/taggle.css");
            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/animate.css",
                "~/Content/style.css",
                "~/Content/style_override.css"));


            bundles.Add(new StyleBundle("~/Content/awesomeCheckbox").Include(
                "~/Content/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                "~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            //// dataPicker styles
            //bundles.Add(new StyleBundle("~/plugins/dataPickerStyles").Include(
            //          "~/Content/plugins/datapicker/datepicker3.css"));

            // dataPicker 

            // wizardSteps styles

            // wizardSteps 

            //// validate 
            //bundles.Add(new ScriptBundle("~/plugins/validate").Include(
            //          "~/Scripts/plugins/validate/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/validateUnobtrusive").Include(
                "~/Scripts/jquery.validate.unobtrusive.min.js", "~/Scripts/jquery.validate.min.js"));

            // nouislider


            SummerNote();
        }

        private static void SummerNote()
        {
            RegisterCss(Bundles.Css.Summernote, "~/Scripts/summernote/summernote.css");
        }


        private static void RegisterCss(string virtualPath, params string[] includes)
        {
            _bundles.Add(new StyleBundle(virtualPath).Include(includes));
        }

        private static void RegisterScripts(string virtualPath, params string[] includes)
        {
            //var includesString = string.Join(",", includes);
            _bundles.Add(new ScriptBundle(virtualPath).Include(includes));
        }
    }
}