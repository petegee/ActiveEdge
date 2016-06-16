using System.Net;
using System.Web.Mvc;
using ActiveEdge.Models;
using ActiveEdge.Models.Shared;
using AutoMapper;
using Domain;
using Domain.Command;
using Domain.Command.Client;
using Domain.Context;
using Domain.Query.Clients;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IApplicationDbContext _database;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public ClientController(IApplicationDbContext database, IBus bus, IMapper mapper,
            MapperConfiguration mapperConfiguration)
        {
            _database = database;
            _bus = bus;
            _mapper = mapper;
            _mapperConfiguration = mapperConfiguration;
        }


        // GET: /Client/
        [HttpGet]
        public ActionResult Index()
        {
            var clients =
                _bus.ExecuteQuery(new GetAllClientsForOrganization(OrganizationId))
                    .ProjectToList<ClientModel>(_mapperConfiguration);

            return View(clients);
        }

        // GET: /Client/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _bus.ExecuteQuery(new GetClientForOrganization(id.Value));
                

            if (client == null)
            {
                return HttpNotFound();
            }

            var model = _mapper.Map<ClientModel>(client);

            return View(model);
        }

        [HttpGet]
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

            var cmd = _mapper.Map<RegisterNewClientCommand>(client);
            
            _bus.ExecuteCommand(cmd);

            Notify(new SuccessMessage("Client successfully registered."));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = _bus.ExecuteQuery(new GetClientForOrganization(id.Value));


            if (client == null)
            {
                return HttpNotFound();
            }

            var model = _mapper.Map<ClientModel>(client);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientModel clientModel)
        {
            if (ModelState.IsValid)
            {
                var cmd = _mapper.Map<UpdateClientCommand>(clientModel);

                _bus.ExecuteCommand(cmd);

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
            var client = _bus.ExecuteQuery(new GetClientForOrganization(id.Value));

            if (client == null)
            {
                return HttpNotFound();
            }

            var model = _mapper.Map<ClientModel>(client);

            return View(model);
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bus.ExecuteCommand(new DeleteClientCommand(id));

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