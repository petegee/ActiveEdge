using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using ActiveEdge.Read.Model.Shared;
using Domain;
using Shared;

namespace ActiveEdge.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly ILoggedOnUser _loggedOnUser;
        private const string UiNotificationKey = "UINotificationKey";

        protected ControllerBase(ILoggedOnUser loggedOnUser)
        {
            _loggedOnUser = loggedOnUser;
            
        }

        protected void AppendAuditableInformation(IAmAuditable auditableCommand)
        {
            auditableCommand.UserName = _loggedOnUser.UserName;
            auditableCommand.UserId = _loggedOnUser.Id;
            auditableCommand.CommandDate = DateTime.Now;
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
            {
                ViewBag.Alert = alert;
            }

            base.OnResultExecuting(filterContext);
        }
    }
}