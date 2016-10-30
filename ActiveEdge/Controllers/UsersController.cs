using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActiveEdge.Infrastructure;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Shared;
using ActiveEdge.Read.Model.Users;
using ActiveEdge.Read.Query.User;
using AutoMapper;
using Domain.Command.User;
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
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public UsersController(IBus bus,
            ApplicationUserManager userManager, ILoggedOnUser loggedOnUser, IMapper mapper) : base(loggedOnUser)
        {
            _bus = bus;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("organization/users/{id}")]
        public ActionResult ForOrganization(Guid id)
        {
            var users = _bus.ExecuteQuery(new FindAllUsersForOrganization(id));

            return View(users);
        }

        [HttpGet]
        [Route("create/user")]
        [HandleValidationErrors]
        public ActionResult Create()
        {
            return View(new UserModel());
        }

        [HttpPost]
        [Route("create/user")]
        [HandleValidationErrors]
        public async Task<ActionResult> Create(UserModel model)
        {
            var command = _mapper.Map<CreateNewUser>(model);

            await _bus.ExecuteAsyncCommand(command);

            Notify<SuccessMessage>("user successfully created.");

            return RedirectToAction("Index");
        }

        [Route("users")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}