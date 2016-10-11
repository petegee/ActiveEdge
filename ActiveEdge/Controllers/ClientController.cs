using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Shared;
using AutoMapper;
using Domain.Command.Client;
using Domain.Filters;
using Marten;
using Shared;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public ClientController(IBus bus, IMapper mapper, IDocumentSession session)
        {
            _bus = bus;
            _mapper = mapper;
            _session = session;
        }


        [HttpGet]
        [Route("clients")]
        public ActionResult Index()
        {
            var clients = _session.Query<ClientModel>().FilterForOrganization(OrganizationId).ToList();

            return View(clients);
        }

        [HttpGet]
        [Route("client/{id}")]
        public ActionResult Details(Guid id)
        {
            var client = _session.Query<ClientModel>().SingleOrDefault(c => c.Id == id);
            
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        [HttpGet]
        [Route("client/intake")]
        [HandleValidationErrors]
        public ActionResult Create()
        {
            return View("Intake", new ClientModel());
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("client/intake")]
        [HandleValidationErrors(Action = "Create", Controller = "Create")]
        public async Task<RedirectToRouteResult> Create([Bind(Exclude = "Id")] ClientModel client)
        {
            var cmd = _mapper.Map<RegisterNewClient>(client);

            cmd.OrganizationId = OrganizationId;

            await _bus.ExecuteAsyncCommand(cmd);

            Notify(new SuccessMessage("Client successfully registered."));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("client/edit/{id}")]
        [HandleValidationErrors]
        public ActionResult Edit(Guid id)
        {
            var client = _session.Query<ClientModel>().SingleOrDefault(c => c.Id == id);
            
            if (client == null)
            {
                return HttpNotFound();
            }


            return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("client/edit/{id}")]
        [HandleValidationErrors]
        public ActionResult Edit(ClientModel clientModel)
        {
            var cmd = _mapper.Map<UpdateClientCommand>(clientModel);

            _bus.ExecuteCommand(cmd);

            Notify<SuccessMessage>($"{cmd.FirstName} {cmd.LastName} successfully updated.");

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("client/delete/{id}")]
        public ActionResult Delete(Guid id)
        {

            var client = _session.Query<ClientModel>().SingleOrDefault(c => c.Id == id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("client/delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bus.ExecuteCommand(new DeleteClientCommand(id));

            Notify<SuccessMessage>("Client successfully deleted");

            return RedirectToAction("Index");
        }
    }
}