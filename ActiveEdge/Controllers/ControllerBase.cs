using System.Web.Mvc;
using ActiveEdge.Models.Shared;

namespace ActiveEdge.Controllers
{


    public abstract class ControllerBase : Controller
    {
        private const string UiNotificationKey = "UINotificationKey";

        public void Notify(Message message)
        {
            TempData[UiNotificationKey] = message;
        }

        /// <summary>Called before the action result that is returned by an action method is executed.</summary>
        /// <param name="filterContext">Information about the current request and action result.</param>
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var alert = TempData[UiNotificationKey];

            if (alert != null)
            {
                ViewBag.Alert = alert;
            }

            base.OnResultExecuting(filterContext);
        }
    }
}