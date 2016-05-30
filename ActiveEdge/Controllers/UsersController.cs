using System;
using System.Linq;
using System.Web.Mvc;
using ActiveEdge.Infrastructure;
using ActiveEdge.Models.Shared;
using ActiveEdge.Models.Users;
using AutoMapper;
using Domain.Context;
using Domain.Model;
using Domain.Query.User;
using MediatR;
using Microsoft.AspNet.Identity;

namespace ActiveEdge.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMediator _mediator;
        private readonly ApplicationUserManager _userManager;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public UsersController(IMediator mediator, MapperConfiguration mapperConfiguration,
            ApplicationUserManager userManager)
        {
            _mediator = mediator;
            _mapperConfiguration = mapperConfiguration;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult ForOrganization(int id)
        {
            var users = _mediator.Send(new FindAllUsersForOrganization(id)).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult CreateForOrganization(int id)
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