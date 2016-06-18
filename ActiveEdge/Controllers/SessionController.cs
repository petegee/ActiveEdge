using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.Extensions;
using ActiveEdge.Read.Model;
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
        private readonly MapperConfiguration _mapperConfiguration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public SessionController(IMapper mapper,
            MapperConfiguration mapperConfiguration, IBus bus)
        {
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
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
        [Route("sessions/for/client/{id}", Name = "session-forclient")]
        public ActionResult ForClient(int id)
        {
            var sessions = _bus.ExecuteQuery(new GetAllSessionsForClient(id));

            return View("Index", sessions);
        }

        [HttpGet]
        [Route("session/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var session = _bus.ExecuteQuery(new GetSessionById(id.Value));

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
        public ActionResult Plan(int? id)
        {
            return Edit(id);
        }

        [HttpGet]
        [Route("session/edit/{id}", Name = "session-edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var session = _bus.ExecuteQuery(new GetSessionById(id.Value));

            if (session == null)
            {
                return HttpNotFound();
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
        [Route("session/edit")]
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var session = _bus.ExecuteQuery(new GetSessionById(id.Value));

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