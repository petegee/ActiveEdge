using System.Web.Optimization;

namespace ActiveEdge
{
  public static class Bundles
  {
    public static class Css
    {
      public const string Summernote = "~/bundles/summernotestyles";
    }

    public static class Scripts
    {
      public const string ActiveEdge = "~/bundles/activeedge";
      public const string Client = "~/bundles/client";
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

      SoapNoteScripts(bundles);

      // Vendor scripts
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-2.1.1.min.js"));

      // jQuery Validation
      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
      "~/Scripts/jquery.validate.min.js"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

      // Inspinia script
      bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                "~/Scripts/app/inspinia.js"));

      // SlimScroll
      bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js"));

      // jQuery plugins
      bundles.Add(new ScriptBundle("~/plugins/metsiMenu").Include(
                "~/Scripts/plugins/metisMenu/metisMenu.min.js"));

      bundles.Add(new ScriptBundle("~/plugins/pace").Include(
                "~/Scripts/plugins/pace/pace.min.js"));

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

      // dataPicker styles
      bundles.Add(new StyleBundle("~/plugins/dataPickerStyles").Include(
                "~/Content/plugins/datapicker/datepicker3.css"));

      // dataPicker 
      bundles.Add(new ScriptBundle("~/plugins/dataPicker").Include(
                "~/Scripts/plugins/datapicker/bootstrap-datepicker.js"));

      // wizardSteps styles
      bundles.Add(new StyleBundle("~/plugins/wizardStepsStyles").Include(
                "~/Content/plugins/steps/jquery.steps.css"));

      // wizardSteps 
      bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
                "~/Scripts/plugins/steps/jquery.steps.min.js"));

      // validate 
      bundles.Add(new ScriptBundle("~/plugins/validate").Include(
                "~/Scripts/plugins/validate/jquery.validate.min.js"));

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

    

    private static void SoapNoteScripts(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/soapnotes").Include(
                    "~/Scripts/site/soapnotes/Create.js"));
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
