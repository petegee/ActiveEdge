using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using ActiveEdge.Read.Model.Shared;
using Shared;

namespace ActiveEdge.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private const string UiNotificationKey = "UINotificationKey";
        protected ILoggedOnUser LoggedOnUser { get; }

        protected ControllerBase(ILoggedOnUser loggedOnUser)
        {
            LoggedOnUser = loggedOnUser;
        }


        protected Guid? OrganizationId
        {
            get
            {
                var identity = (ClaimsIdentity) User.Identity;
                var claims = identity.Claims;

                var organizationClaim = claims.FirstOrDefault(claim => claim.Type == ActiveEdgeClaims.OrganizationId);

                return organizationClaim == null ? (Guid?) null : Guid.Parse(organizationClaim.Value);
            }
        }

        protected void Notify<TMessage>(string message) where TMessage : Message, new()
        {
            var displayMessage = new TMessage {Text = new MvcHtmlString(message)};
            TempData[UiNotificationKey] = displayMessage;
        }

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
                ViewBag.Alert = alert;

            base.OnResultExecuting(filterContext);
        }
    }
}