using System.Web.Mvc;
using System.Web.Routing;
using ActiveEdge.Read.Model.Shared;
using Domain;
using ControllerBase = ActiveEdge.Controllers.ControllerBase;
namespace ActiveEdge.Infrastructure.MVC.Attributes
{
    /// <summary>
    /// This attribute will check whether the ModelState is valid for an incoming POST request and Redirect to the corresponding GET Action on the controller with
    /// the ModelState copied across.
    /// It will also hand BusinessRuleValidation errors. 
    /// </summary>
    public class HandleValidationErrorsAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private const string Modelstate = "ModelState";

        public string Controller { get; set; }

        /// <summary>
        /// The Action to redirect to if the Model is Invalid.
        /// </summary>
        public string Action { get; set; }

        public string[] Parameters { get; set; }

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType() == typeof(BusinessRuleException))
            {
                var controllerBase = filterContext.Controller as ControllerBase;

                if (controllerBase == null) return;

                var exception = (BusinessRuleException)filterContext.Exception;

                foreach (var error in exception.Errors)
                    controllerBase.Notify(new DangerMessage(error));

                filterContext.Result = RedirectToRoute(filterContext);
                filterContext.Controller.TempData[Modelstate] = filterContext.Controller.ViewData.ModelState;

                filterContext.ExceptionHandled = true;
            }
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod == "POST")
            {
                var viewData = filterContext.Controller.ViewData;

                if (!viewData.ModelState.IsValid)
                {
                    // Redirect back to appropriate GET action if the modelstate is invalid..
                    filterContext.Result = RedirectToRoute(filterContext);
                    filterContext.Controller.TempData[Modelstate] = filterContext.Controller.ViewData.ModelState;
                }
            }

            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext.Request.HttpMethod == "GET")
                if (filterContext.Controller.TempData.ContainsKey(Modelstate))
                    filterContext.Controller.ViewData.ModelState.Merge(
                        (ModelStateDictionary)filterContext.Controller.TempData[Modelstate]);
        }

        private ActionResult RedirectToRoute(ControllerContext controllerContext)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"controller", Controller ?? controllerContext.RouteData.Values["controller"]},
                {"action", Action ?? controllerContext.RouteData.Values["action"]}
            };


            if (Parameters != null)
                foreach (var actionParameter in Parameters)
                {
                    var routeParameter = controllerContext.HttpContext.Request.QueryString[actionParameter] ??
                                         controllerContext.HttpContext.Request.Form[actionParameter];

                    if (routeParameter != null)
                        routeValueDictionary.Add(actionParameter, routeParameter);
                }
            return new RedirectToRouteResult(routeValueDictionary);
        }
    }
}