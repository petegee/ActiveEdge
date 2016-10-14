using System;
using System.Web.Mvc;
using ActiveEdge.Infrastructure;
using ActiveEdge.Read.Model.Shared;
using ActiveEdge.Read.Model.Users;
using ActiveEdge.Read.Query.User;
using Domain.Context;
using Domain.Model;
using Microsoft.AspNet.Identity;
using Shared;

namespace ActiveEdge.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly ApplicationUserManager _userManager;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public UsersController(IBus bus,
            ApplicationUserManager userManager, ILoggedOnUser loggedOnUser) : base(loggedOnUser)
        {
            _bus = bus;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult ForOrganization(Guid id)
        {
            var users = _bus.ExecuteQuery(new FindAllUsersForOrganization(id));

            return View(users);
        }

        [HttpGet]
        public ActionResult CreateForOrganization(Guid id)
        {
            return View(new CreateForOrganizationModel {OrganizationId = id});
        }

        [HttpPost]
        public ActionResult CreateForOrganization(CreateForOrganizationModel model)
        {
            var user = new ApplicationUser();

            user.UserName = model.EmailAddress;
            user.Email = model.EmailAddress;
            user.OrganizationId = model.OrganizationId;

            var result = _userManager.Create(user, Guid.NewGuid().ToString());
            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, Roles.OrganizationAdministrator);

                var code = _userManager.GenerateEmailConfirmationToken(user.Id);
                var callbackUrl = Url.Action(
                    "ConfirmEmail", "Account",
                    new {userId = user.Id, code},
                    protocol: Request.Url.Scheme);

                _userManager.SendEmail(user.Id,
                    "Confirm your account",
                    "Please confirm your account by clicking this link: <a href=\""
                    + callbackUrl + "\">link</a>");

                Notify(new SuccessMessage("Organization Administrator sucessfully created."));

                return RedirectToAction("Index", "Organization");
            }

            return RedirectToAction("Index", "Organization");
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}