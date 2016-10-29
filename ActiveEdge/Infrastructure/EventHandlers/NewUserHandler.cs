using ActiveEdge.Infrastructure.MVC;
using Domain;
using Domain.Event.User;
using Shared;

namespace ActiveEdge.Infrastructure.EventHandlers
{
    public class NewUserHandler : IDomainEventHandler<UserCreated>
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IApplicationUserManager _userManager;

        public NewUserHandler(IApplicationUserManager userManager, IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _urlHelper = urlHelper;
        }

        public void Handle(UserCreated notification)
        {
            var code = _userManager.GenerateEmailConfirmationTokenAsync(notification.UserId);

            var callbackUrl = _urlHelper.Action("ConfirmEmail", "Account", new {userId = notification.UserId, code});

            _userManager.SendEmailAsync(notification.UserId,
                "Confirm your account",
                "Please confirm your account by clicking this link: <a href=\""
                + callbackUrl + "\">link</a>");
        }
    }
}