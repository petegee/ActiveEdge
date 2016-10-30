using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActiveEdge.Infrastructure;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Shared;
using ActiveEdge.Read.Model.Users;
using ActiveEdge.Read.Query.User;
using AutoMapper;
using Domain.Command.User;
using Domain.Model;
using Marten;
using Shared;

namespace ActiveEdge.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public UsersController(IBus bus,
            ApplicationUserManager userManager, ILoggedOnUser loggedOnUser, IMapper mapper, IDocumentSession session)
            : base(loggedOnUser)
        {
            _bus = bus;
            _mapper = mapper;
            _session = session;
        }

        [HttpGet]
        [Route("organization/users/{id}")]
        public async Task<ActionResult> ForOrganization(Guid id)
        {
            var users = await _bus.ExecuteAsyncQuery(new FindAllUsersForOrganization(id));

            return View(users);
        }

        [HttpGet]
        [Route("user/create")]
        [HandleValidationErrors]
        public ActionResult Create()
        {
            return View(new UserModel());
        }


        [HttpPost]
        [Route("user/create")]
        [ValidateAntiForgeryToken]
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
        public async Task<ActionResult> Index()
        {
            var users = await _session.Query<ApplicationUser>().Select(user => new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = user.Roles
                })
                .ToListAsync();

            var model = new AllUsers {Users = users};

            return View(model);
        }

        [HttpGet]
        [Route("user/details/{id}")]
        [HandleValidationErrors]
        public async Task<ActionResult> Details(string id)
        {
            var userModel = await _session.Query<ApplicationUser>()
                .Where(user => user.Id == id)
                .Select(user => new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = user.Roles
                })
                .SingleOrDefaultAsync();

            return View(userModel);
        }

        [HttpGet]
        [Route("user/edit/{id}")]
        [HandleValidationErrors]
        public async Task<ActionResult> Edit(string id)
        {
            var userModel = await _session
                .Query<ApplicationUser>()
                .Where(user => user.Id == id)
                .Select(user => new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = user.Roles
                })
                .SingleOrDefaultAsync();

            return View(userModel);
        }
    }
}