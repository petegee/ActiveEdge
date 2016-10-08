using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ActiveEdge.Infrastructure.MVC
{
    public class UrlDecoratorHelper : IUrlHelper
    {
        private readonly UrlHelper _urlHelper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public UrlDecoratorHelper()
        {
            _urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
        }

        /// <summary>Generates a string to a fully qualified URL to an action method.</summary>
        /// <returns>A string to a fully qualified URL to an action method.</returns>
        public string Action()
        {
            return _urlHelper.Action();
        }

        /// <summary>Generates a fully qualified URL to an action method by using the specified action name.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        public string Action(string actionName)
        {
            return _urlHelper.Action(actionName);
        }

        /// <summary>Generates a fully qualified URL to an action method by using the specified action name and route values.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        public string Action(string actionName, object routeValues)
        {
            return _urlHelper.Action(actionName, routeValues);
        }

        /// <summary>Generates a fully qualified URL to an action method for the specified action name and route values.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        public string Action(string actionName, RouteValueDictionary routeValues)
        {
            return _urlHelper.Action(actionName, routeValues);
        }

        /// <summary>Generates a fully qualified URL to an action method by using the specified action name and controller name.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        public string Action(string actionName, string controllerName)
        {
            return _urlHelper.Action(actionName, controllerName);
        }

        /// <summary>Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        public string Action(string actionName, string controllerName, object routeValues)
        {
            return _urlHelper.Action(actionName, controllerName, routeValues);
        }

        /// <summary>Generates a fully qualified URL to an action method by using the specified action name, controller name, and route values.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        public string Action(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return _urlHelper.Action(actionName, controllerName, routeValues);
        }

        /// <summary>Generates a fully qualified URL for an action method by using the specified action name, controller name, route values, and protocol to use.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        public string Action(string actionName, string controllerName, RouteValueDictionary routeValues, string protocol)
        {
            return _urlHelper.Action(actionName, controllerName, routeValues, protocol);
        }

        /// <summary>Generates a fully qualified URL to an action method by using the specified action name, controller name, route values, and protocol to use.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        public string Action(string actionName, string controllerName, object routeValues, string protocol)
        {
            return _urlHelper.Action(actionName, controllerName, routeValues, protocol);
        }

        /// <summary>Generates a fully qualified URL for an action method by using the specified action name, controller name, route values, protocol to use and host name.</summary>
        /// <returns>The fully qualified URL to an action method.</returns>
        /// <param name="actionName">The name of the action method.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        /// <param name="hostName">The host name for the URL.</param>
        public string Action(string actionName, string controllerName, RouteValueDictionary routeValues, string protocol,
            string hostName)
        {
            return _urlHelper.Action(actionName, controllerName, routeValues, protocol, hostName);
        }

        /// <summary>Converts a virtual (relative) path to an application absolute path.</summary>
        /// <returns>The application absolute path.</returns>
        /// <param name="contentPath">The virtual path of the content.</param>
        public string Content(string contentPath)
        {
            return _urlHelper.Content(contentPath);
        }

        /// <summary>Encodes special characters in a URL string into character-entity equivalents.</summary>
        /// <returns>An encoded URL string.</returns>
        /// <param name="url">The text to encode.</param>
        public string Encode(string url)
        {
            return _urlHelper.Encode(url);
        }

        /// <summary>Returns a value that indicates whether the URL is local.</summary>
        /// <returns>true if the URL is local; otherwise, false.</returns>
        /// <param name="url">The URL.</param>
        public bool IsLocalUrl(string url)
        {
            return _urlHelper.IsLocalUrl(url);
        }

        /// <summary>Generates a fully qualified URL for the specified route values.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        public string RouteUrl(object routeValues)
        {
            return _urlHelper.RouteUrl(routeValues);
        }

        /// <summary>Generates a fully qualified URL for the specified route values.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        public string RouteUrl(RouteValueDictionary routeValues)
        {
            return _urlHelper.RouteUrl(routeValues);
        }

        /// <summary>Generates a fully qualified URL for the specified route name.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeName">The name of the route that is used to generate URL.</param>
        public string RouteUrl(string routeName)
        {
            return _urlHelper.RouteUrl(routeName);
        }

        /// <summary>Generates a fully qualified URL for the specified route values by using a route name.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeName">The name of the route that is used to generate URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        public string RouteUrl(string routeName, object routeValues)
        {
            return _urlHelper.RouteUrl(routeName, routeValues);
        }

        /// <summary>Generates a fully qualified URL for the specified route values by using a route name.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeName">The name of the route that is used to generate URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        public string RouteUrl(string routeName, RouteValueDictionary routeValues)
        {
            return _urlHelper.RouteUrl(routeName, routeValues);
        }

        /// <summary>Generates a fully qualified URL for the specified route values by using a route name and the protocol to use.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeName">The name of the route that is used to generate the URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        public string RouteUrl(string routeName, object routeValues, string protocol)
        {
            return _urlHelper.RouteUrl(routeName, routeValues, protocol);
        }

        /// <summary>Generates a fully qualified URL for the specified route values by using the specified route name, protocol to use, and host name.</summary>
        /// <returns>The fully qualified URL.</returns>
        /// <param name="routeName">The name of the route that is used to generate URL.</param>
        /// <param name="routeValues">An object that contains the parameters for a route.</param>
        /// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
        /// <param name="hostName">The host name for the URL.</param>
        public string RouteUrl(string routeName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return _urlHelper.RouteUrl(routeName, routeValues, protocol, hostName);
        }

        /// <summary>Generates a fully qualified URL for the specified route values.</summary>
        /// <returns>A fully qualified URL for the specified route values.</returns>
        /// <param name="routeName">The route name.</param>
        /// <param name="routeValues">The route values.</param>
        public string HttpRouteUrl(string routeName, object routeValues)
        {
            return _urlHelper.HttpRouteUrl(routeName, routeValues);
        }

        /// <summary>Generates a fully qualified URL for the specified route values.</summary>
        /// <returns>A fully qualified URL for the specified route values.</returns>
        /// <param name="routeName">The route name.</param>
        /// <param name="routeValues">The route values.</param>
        public string HttpRouteUrl(string routeName, RouteValueDictionary routeValues)
        {
            return _urlHelper.HttpRouteUrl(routeName, routeValues);
        }

        /// <summary>Gets information about an HTTP request that matches a defined route.</summary>
        /// <returns>The request context.</returns>
        public RequestContext RequestContext
        {
            get { return _urlHelper.RequestContext; }
        }

        /// <summary>Gets a collection that contains the routes that are registered for the application.</summary>
        /// <returns>The route collection.</returns>
        public RouteCollection RouteCollection
        {
            get { return _urlHelper.RouteCollection; }
        }
    }
}