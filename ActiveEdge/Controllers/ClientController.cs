using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ActiveEdge.Database;
using AutoMapper;
using Domain;

namespace ActiveEdge.Controllers
{
  public class ClientController : Controller
  {
    private readonly IApplicationDbContext _database;
    private readonly IMapper _mapper;
    private readonly MapperConfiguration _mapperConfiguration;

    /// <summary>
    ///   Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
    /// </summary>
    public ClientController(IApplicationDbContext database, IMapper mapper, MapperConfiguration mapperConfiguration)
    {
      _database = database;
      _mapper = mapper;
      _mapperConfiguration = mapperConfiguration;
    }


    // GET: /Customer/
    public ActionResult Index()
    {
      return View(_database.Clients.ProjectToList<Models.Client>(_mapperConfiguration));
    }

    // GET: /Customer/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customer = _database.Clients.Where(c => c.Id == id.Value).ProjectToSingle<Models.Client>(_mapperConfiguration);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // GET: /Customer/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: /Customer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Exclude = "Id")] Models.Client client)
    {
      if (ModelState.IsValid)
      {
        var customerDomain = _mapper.Map<Models.Client, Client>(client);

        _database.Clients.Add(customerDomain);
        _database.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(client);
    }

    // GET: /Customer/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customer = _database.Clients.Where(c => c.Id == id.Value).ProjectToSingle<Models.Client>(_mapperConfiguration); 
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: /Customer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Models.Client client)
    {
      if (ModelState.IsValid)
      {
        var customerDomain = _mapper.Map<Models.Client, Client>(client);
        _database.Entry(customerDomain).State = EntityState.Modified;
        _database.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(client);
    }

    // GET: /Customer/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customer = _database.Clients.Where(c => c.Id == id.Value).ProjectToSingle<Models.Client>(_mapperConfiguration); 
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: /Customer/Delete/5
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