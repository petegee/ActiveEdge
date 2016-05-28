using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Models;
using ActiveEdge.Models.Shared;
using AutoMapper;
using Domain.Context;
using Domain.Model;
using MediatR;

namespace ActiveEdge.Controllers
{
  [Authorize]
  public class ClientController : ControllerBase
  {
    private readonly IApplicationDbContext _database;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _mapperConfiguration;
    private readonly IMediator _mediator;

    /// <summary>
    ///   Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
    /// </summary>
    public ClientController(IApplicationDbContext database, IMapper mapper, MapperConfiguration mapperConfiguration, IMediator mediator)
    {
      _database = database;
      _mapper = mapper;
      _mapperConfiguration = mapperConfiguration;
      _mediator = mediator;
    }


    // GET: /Client/
    public ActionResult Index()
    {
      return View(_database.Clients.ProjectToList<ClientModel>(_mapperConfiguration));
    }

    // GET: /Client/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customer = _database.Clients.Where(c => c.Id == id.Value).ProjectToSingleOrDefault<ClientModel>(_mapperConfiguration);

      if (customer == null)
      {
        return HttpNotFound();
      }

      return View(customer);
    }
    
    // GET: /Client/Create
    public ActionResult Create()
    {
      return View("Intake", new ClientModel());
    }

    // POST: /Client/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Exclude = "Id")] ClientModel client)
    {
      if (!ModelState.IsValid) return View("Intake", client);

      _mediator.Publish(client);
      
      Notify(new SuccessMessage("Client successfully registered."));

      return RedirectToAction("Index");
    }

    // GET: /Client/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      
      var customer = _database.Clients.Where(c => c.Id == id.Value).ProjectToSingleOrDefault<ClientModel>(_mapperConfiguration);

      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: /Client/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ClientModel clientModel)
    {
      if (ModelState.IsValid)
      {
        var customerDomain = _mapper.Map<ClientModel, Client>(clientModel);
        _database.Entry(customerDomain).State = EntityState.Modified;
        _database.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(clientModel);
    }

    // GET: /Client/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customer = _database.Clients.Where(c => c.Id == id.Value).ProjectToSingle<ClientModel>(_mapperConfiguration);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: /Client/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      var customer = _database.Clients.Find(id);
      _database.Clients.Remove(customer);
      _database.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _database.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}