﻿using System.Web.Optimization;

namespace ActiveEdge
{
  public static class Bundles
  {
    public static class Css
    {
      public const string Summernote = "~/bundles/summernotestyles";
      public const string DatePicker = "~/bundles/styles/datepicker";
    }

    public static class Scripts
    {
      public const string ActiveEdge = "~/bundles/scripts/activeedge";
      public const string Client = "~/bundles/scripts/client";
      public const string Jquery = "~/bundles/scripts/jquery";
      public const string JqueryValidation = "~/bundles/scripts/jqueryval";
      public const string Bootstrap = "~/bundles/scripts/bootstrap";
      public const string Inspinia = "~/bundles/scripts/inspinia";
      public const string DatePicker = "~/bundles/scripts/dataPicker";
      public const string MetsiMenu = "~/bundles/scripts/metsimenu";
      public const string SlimScroll = "~/bundles/scripts/slimscroll";
      public const string Pace = "~/bundles/scripts/pace";

      public static class Session
      {
        public const string CreateOrEdit = "~/bundles/scripts/session/createoredit";
        public const string Details = "~/bundles/scripts/session/details";
      }
    }
  }
  public class BundleConfig
  {
    
    private static BundleCollection _bundles;

    public static void RegisterBundles(BundleCollection bundles)
    {
      _bundles = bundles;

      RegisterScripts(Bundles.Scripts.ActiveEdge, "~/Scripts/site/activeedge.js", "~/Scripts/typeahead.bundle.min.js", "~/Scripts/bloodhound.min.js", "~/Scripts/summernote/summernote.min.js");

      CustomerScripts(bundles);

      RegisterScripts(Bundles.Scripts.Session.CreateOrEdit, "~/Scripts/site/session/createoredit.js", "~/Scripts/site/session/drawing.js");
      RegisterScripts(Bundles.Scripts.Session.Details, "~/Scripts/site/session/details.js", "~/Scripts/site/session/drawing.js");
      
      // Vendor scripts
      RegisterScripts(Bundles.Scripts.Jquery, "~/Scripts/jquery-2.1.1.min.js");
      RegisterScripts(Bundles.Scripts.JqueryValidation,"~/Scripts/jquery.validate.min.js");
      RegisterScripts(Bundles.Scripts.Bootstrap, "~/Scripts/bootstrap.min.js");
      RegisterScripts(Bundles.Scripts.Inspinia, "~/Scripts/app/inspinia.js");
      RegisterScripts(Bundles.Scripts.DatePicker, "~/Scripts/plugins/datapicker/bootstrap-datepicker.js");
      RegisterScripts(Bundles.Scripts.MetsiMenu, "~/Scripts/plugins/metisMenu/metisMenu.min.js");
      RegisterScripts(Bundles.Scripts.SlimScroll, "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js");
      RegisterScripts(Bundles.Scripts.Pace, "~/Scripts/plugins/pace/pace.min.js");


      RegisterCss(Bundles.Css.DatePicker, "~/Content/plugins/datapicker/datepicker3.css");

     
     
      // CSS style (bootstrap/inspinia)
      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/animate.css",
                "~/Content/style.css",
                "~/Content/style_override.css"));

      // iCheck css styles
      bundles.Add(new StyleBundle("~/Content/plugins/iCheck/iCheckStyles").Include(
                "~/Content/plugins/iCheck/custom.css"));

      // iCheck
      bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
                "~/Scripts/plugins/iCheck/icheck.min.js"));


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
      bundles.Add(new StyleBundle("~/plugins/wizardStepsStyles").Include(
                "~/Content/plugins/steps/jquery.steps.css"));

      // wizardSteps 
      bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
                "~/Scripts/plugins/steps/jquery.steps.min.js"));

      //// validate 
      //bundles.Add(new ScriptBundle("~/plugins/validate").Include(
      //          "~/Scripts/plugins/validate/jquery.validate.min.js"));

      bundles.Add(new ScriptBundle("~/validateUnobtrusive").Include(
                "~/Scripts/jquery.validate.unobtrusive.min.js", "~/Scripts/jquery.validate.min.js"));

      // nouislider
      bundles.Add(new ScriptBundle("~/plugins/nouislider").Include("~/Scripts/plugins/nouslider/jquery.nouislider.min.js"));
      bundles.Add(new StyleBundle("~/plugins/nouisliderStyles").Include("~/Content/plugins/nouslider/jquery.nouislider.css"));

    

      SummerNote();
    }

    private static void SummerNote()
    {
      RegisterCss(Bundles.Css.Summernote, "~/Scripts/summernote/summernote.css");
    }

    

    

    private static void CustomerScripts(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle(Bundles.Scripts.Client).Include(
                   "~/Scripts/site/client/Create.js"));
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
