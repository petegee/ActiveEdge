using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.Extensions;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Session;
using ActiveEdge.Read.Model.Shared;
using AutoMapper;
using Domain.Command.Session;
using Domain.Filters;
using Marten;
using Shared;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public SessionController(IMapper mapper, IBus bus, IDocumentSession session)
        {
            _mapper = mapper;
            _bus = bus;
            _session = session;
        }
        
        [HttpGet]
        [Route("sessions")]
        public async Task<ViewResult> Index()
        {
            var sessions = await _session.Query<SessionModel>()
                .FilterFor(OrganizationId)
                .ToListAsync();

            return View(sessions);
        }

        [HttpGet]
        [Route("sessions/for/client/{id}")]
        public async Task<ActionResult> ForClient(Guid id)
        {
            var sessions = await _session.Query<SessionModel>()
                .Where(model => model.ClientId == id)
                .ToListAsync();

            return View("Index", sessions);
        }

        [HttpGet]
        [Route("session/{id}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var session = await GetSessionModel(id);

            if (session == null)
            {
                return HttpNotFound();
            }

            return View(session);
        }

        private async Task<SessionModel> GetSessionModel(Guid id)
        {
            var session = await
                _session.Query<SessionModel>()
                    .FilterFor(OrganizationId)
                    .SingleOrDefaultAsync(sessionModel => sessionModel.Id == id);
            return session;
        }

        [HttpGet]
        [Route("session/new")]
        public ActionResult Create()
        {
            var model = new SessionModel {Date = DateTime.Now.Date};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("session/new")]
        [HandleValidationErrors]
        public async Task<ActionResult> Create([Bind(Exclude = "Id")] SessionModel sessionModel)
        {
            var command = _mapper.Map<CreateNewSession>(sessionModel);

            command.OrganizationId = OrganizationId;

            var sessionId = await _bus.ExecuteAsyncCommand(command);

            Notify(new SuccessMessage("Session created succesfully."));

            return RedirectToAction("Plan", new {id = sessionId});
        }

        [HttpGet]
        [Route("session/plan/{id}")]
        [HandleValidationErrors]
        public async Task<ActionResult> Plan(Guid id)
        {
            return await Edit(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("session/plan/{id}")]
        [HandleValidationErrors]
        public async Task<RedirectToRouteResult> Plan(SessionPlanModel sessionModel)
        {
            var command = _mapper.Map<AddPlanToSession>(sessionModel);

            await _bus.ExecuteAsyncCommand(command);

            Notify(new SuccessMessage("Session successfully updated."));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("session/edit/{id}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var session = await GetSessionModel(id);

            if (session == null)
            {
                Notify<WarningMessage>("Unknown Session");

                return RedirectToAction("Index");
            }

            if (session.ContraIndications.Any())
            {
                Notify(
                    new DangerMessage(
                        $"<b>Warning</b> the user has the following conditions:<b> {session.ContraIndications.ToCommaDelimited()}</b>"));
            }

            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("session/edit/{id}")]
        public ActionResult Edit(SessionModel sessionModel)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateSessionCommand>(sessionModel);

                _bus.ExecuteCommand(command);

                Notify(new SuccessMessage("Session successfully updated."));

                return RedirectToAction("Index");
            }

            return View(sessionModel);
        }

        [HttpGet]
        [Route("session/delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var session = await GetSessionModel(id);

            if (session == null)
            {
                return HttpNotFound();
            }

            return View(session);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("session/delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bus.ExecuteCommand(new DeleteSessionCommand {Id = id});

            Notify(new SuccessMessage("Session successfuly deleted."));

            return RedirectToAction("Index");
        }
    }
}