﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Database;
using ActiveEdge.Models;
using AutoMapper;
using Domain;

namespace ActiveEdge.Controllers
{
  [Authorize]
  public class SoapNotesController : Controller
  {

    private IApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _mapperConfiguration;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller"/> class.
    /// </summary>
    public SoapNotesController(IApplicationDbContext applicationDbContext,IMapper mapper, MapperConfiguration mapperConfiguration)
    {
      _db = applicationDbContext;
      _mapper = mapper;
      _mapperConfiguration = mapperConfiguration;
    }

    // GET: /SoapNotes/
    public ActionResult Index()
    {
      return View(_db.SoapNotes.ProjectToList<SoapNoteModel>(_mapperConfiguration));
    }

    // GET: /SoapNotes/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var soapNoteModel = _db.SoapNotes.Where(note => note.Id == id).ProjectToSingleOrDefault<SoapNoteModel>(_mapperConfiguration);
      if (soapNoteModel == null)
      {
        return HttpNotFound();
      }
      return View(soapNoteModel);
    }

    // GET: /SoapNotes/Create
    public ActionResult Create()
    {
      var model = new SoapNoteModel {Date = DateTime.Now};

      return View(model);
    }

    // POST: /SoapNotes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(
      [Bind(Exclude = "Id")] SoapNoteModel soapNoteModel)
    {
      if (ModelState.IsValid)
      {
        var domainModel = _mapper.Map<SoapNoteModel, SoapNote>(soapNoteModel);
        _db.SoapNotes.Add(domainModel);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(soapNoteModel);
    }

    // GET: /SoapNotes/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var soapNoteModel = _db.SoapNotes.Where(note => note.Id == id).ProjectToSingleOrDefault<SoapNoteModel>(_mapperConfiguration);
      if (soapNoteModel == null)
      {
        return HttpNotFound();
      }
      return View(soapNoteModel);
    }

    // POST: /SoapNotes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(
      [Bind(
        Include =
          "Id,Date,ClientId,ClientName,Feedback,GoalOrExpectations,ContributingFactorsToCondition,PreMassagePalpatation,PressureScaleRequired,SessionPlan"
        )] SoapNoteModel soapNoteModel)
    {
      if (ModelState.IsValid)
      {
        var domainModel = _mapper.Map<SoapNoteModel, SoapNote>(soapNoteModel);

        _db.Entry(domainModel).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(soapNoteModel);
    }

    // GET: /SoapNotes/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var soapNoteModel = _db.SoapNotes.Where(note => note.Id == id).ProjectToSingleOrDefault<SoapNoteModel>(_mapperConfiguration);

     
      if (soapNoteModel == null)
      {
        return HttpNotFound();
      }
      return View(soapNoteModel);
    }

    // POST: /SoapNotes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      var soapNoteModel = _db.SoapNotes.Find(id);
      _db.SoapNotes.Remove(soapNoteModel);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
  }
}