using System;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Models;
using ActiveEdge.Models.Shared;
using AutoMapper;
using Domain;
using Domain.Command.Session;
using Domain.Query.Sessions;

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

        // GET: /Sessions/
        public ActionResult Index()
        {
            var sessions = _bus.ExecuteQuery(new GetAllSessions());

            return View(sessions.ProjectToList<SessionModel>(_mapperConfiguration));
        }

        // GET: /Sessions/Details/5
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

        // GET: /Sessions/Create
        public ActionResult Create()
        {
            var model = new SessionModel {Date = DateTime.Now.Date};
            return View(model);
        }

        // POST: /Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Exclude = "Id")] SessionModel sessionModel)
        {
            if (!ModelState.IsValid) return View(sessionModel);

            var command = _mapper.Map<CreateNewSessionCommand>(sessionModel);

            var sessionId = _bus.ExecuteCommand(command);

            Notify(new SuccessMessage("Session created succesfully."));

            return RedirectToAction("Plan", new {id = sessionId});
        }

        // GET: /Session/Plan
        [HttpGet]
        public ActionResult Plan(int? id)
        {
            return Edit(id);
        }

        // GET: /Sessions/Edit/5
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

            var sessionModel = _mapper.Map<SessionModel>(session);

            return View(sessionModel);
        }

        // POST: /Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: /Sessions/Delete/5
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

        // POST: /Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bus.ExecuteCommand(new DeleteSessionCommand {Id = id});

            Notify(new SuccessMessage("Session successfuly deleted."));

            return RedirectToAction("Index");
        }
    }
}