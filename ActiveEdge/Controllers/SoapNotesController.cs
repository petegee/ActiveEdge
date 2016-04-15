using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Database;
using ActiveEdge.Models;

namespace ActiveEdge.Controllers
{
  [Authorize]
  public class SoapNotesController : Controller
  {
    private readonly ApplicationDbContext db = new ApplicationDbContext();

    // GET: /SoapNotes/
    public ActionResult Index()
    {
      return View(db.SoapNoteModels.ToList());
    }

    // GET: /SoapNotes/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var soapNoteModel = db.SoapNoteModels.Find(id);
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
      [Bind(
        Include =
          "Id,Date,ClientId,ClientName,Feedback,GoalOrExpectations,ContributingFactorsToCondition,PreMassagePalpatation,PressureScaleRequired,SessionPlan"
        )] SoapNoteModel soapNoteModel)
    {
      if (ModelState.IsValid)
      {
        db.SoapNoteModels.Add(soapNoteModel);
        db.SaveChanges();
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
      var soapNoteModel = db.SoapNoteModels.Find(id);
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
        db.Entry(soapNoteModel).State = EntityState.Modified;
        db.SaveChanges();
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
      var soapNoteModel = db.SoapNoteModels.Find(id);
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
      var soapNoteModel = db.SoapNoteModels.Find(id);
      db.SoapNoteModels.Remove(soapNoteModel);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}