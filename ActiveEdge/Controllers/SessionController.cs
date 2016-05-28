using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Models;
using ActiveEdge.Models.Shared;
using AutoMapper;
using Domain.Context;
using Domain.Model;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public SessionController(IApplicationDbContext applicationDbContext, IMapper mapper,
            MapperConfiguration mapperConfiguration)
        {
            _db = applicationDbContext;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
        }

        public ActionResult Drawing()
        {
            return View();
        }

        // GET: /Sessions/
        public ActionResult Index()
        {
            return View(_db.Sessions.ProjectToList<SessionModel>(_mapperConfiguration));
        }

        // GET: /Sessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sessionModel =
                _db.Sessions.Where(note => note.Id == id).ProjectToSingleOrDefault<SessionModel>(_mapperConfiguration);
            if (sessionModel == null)
            {
                return HttpNotFound();
            }
            return View(sessionModel);
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

            var domainModel = _mapper.Map<SessionModel, Session>(sessionModel);
            _db.Sessions.Add(domainModel);
            _db.SaveChanges();

            Notify(new SuccessMessage("Session created succesfully."));

            return RedirectToAction("Plan", new {id = domainModel.Id});
        }

        // GET: /Session/Plan
        [HttpGet]
        public ActionResult Plan(int id)
        {
            var sessionModel =
                _db.Sessions.Where(note => note.Id == id).ProjectToSingleOrDefault<SessionModel>(_mapperConfiguration);

            if (sessionModel == null)
            {
                return HttpNotFound();
            }
            return View(sessionModel);
        }

        // GET: /Sessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sessionModel =
                _db.Sessions.Where(note => note.Id == id).ProjectToSingleOrDefault<SessionModel>(_mapperConfiguration);
            if (sessionModel == null)
            {
                return HttpNotFound();
            }
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
                var domainModel = _mapper.Map<SessionModel, Session>(sessionModel);

                _db.Entry(domainModel).State = EntityState.Modified;
                _db.SaveChanges();

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
            var sessionModel =
                _db.Sessions.Where(note => note.Id == id).ProjectToSingleOrDefault<SessionModel>(_mapperConfiguration);


            if (sessionModel == null)
            {
                return HttpNotFound();
            }
            return View(sessionModel);
        }

        // POST: /Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sessionModel = _db.Sessions.Find(id);
            _db.Sessions.Remove(sessionModel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}