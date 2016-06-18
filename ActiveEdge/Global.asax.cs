using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ActiveEdge.App_Start;
using ActiveEdge.DependencyResolution;
using ActiveEdge.Read;

//using WebApiContrib.IoC.StructureMap;

namespace ActiveEdge
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;

            var container = StructuremapMvc.StructureMapDependencyScope.Container;
            config.DependencyResolver = new StructureMapDependencyResolver(container);

            ModelMetadataProviders.Current = new MetadataProvider();
        }
    }
}