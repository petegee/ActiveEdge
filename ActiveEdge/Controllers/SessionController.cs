using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.Extensions;
using ActiveEdge.Read.Model.Session;
using ActiveEdge.Read.Model.Shared;
using ActiveEdge.Read.Query.Sessions;
using AutoMapper;
using Domain.Command.Session;
using Shared;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public SessionController(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        public ActionResult Drawing()
        {
            return View();
        }

        [HttpGet]
        [Route("sessions")]
        public ActionResult Index()
        {
            var sessions = _bus.ExecuteQuery(new GetAllSessions());

            return View(sessions);
        }

        [HttpGet]
        [Route("sessions/for/client/{id}")]
        public ActionResult ForClient(Guid id)
        {
            var sessions = _bus.ExecuteQuery(new GetAllSessionsForClient(id));

            return View("Index", sessions);
        }

        [HttpGet]
        [Route("session/{id}")]
        public ActionResult Details(Guid id)
        {
            
            var session = _bus.ExecuteQuery(new GetSessionById(id));

            if (session == null)
            {
                return HttpNotFound();
            }

            var model = _mapper.Map<SessionModel>(session);

            return View(model);
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
        public ActionResult Create([Bind(Exclude = "Id")] SessionModel sessionModel)
        {
            if (!ModelState.IsValid) return View(sessionModel);

            var command = _mapper.Map<CreateNewSessionCommand>(sessionModel);

            var sessionId = _bus.ExecuteCommand(command);

            Notify(new SuccessMessage("Session created succesfully."));

            return RedirectToAction("Plan", new {id = sessionId});
        }

        [HttpGet]
        [Route("session/plan/{id}")]
        public ActionResult Plan(Guid id)
        {
            return Edit(id);
        }

        [HttpGet]
        [Route("session/edit/{id}")]
        public ActionResult Edit(Guid id)
        {
           
            var session = _bus.ExecuteQuery(new GetSessionById(id));

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
            var sessionModel = _mapper.Map<SessionModel>(session);

            return View(sessionModel);
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
        public ActionResult Delete(Guid id)
        {
            var session = _bus.ExecuteQuery(new GetSessionById(id));

            if (session == null)
            {
                return HttpNotFound();
            }

            var sessionModel = _mapper.Map<SessionModel>(session);

            return View(sessionModel);
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