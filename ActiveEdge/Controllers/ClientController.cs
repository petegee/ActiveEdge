using System.Net;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Shared;
using ActiveEdge.Read.Query.Clients;
using AutoMapper;
using Domain.Command.Client;
using Shared;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.
        /// </summary>
        public ClientController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("clients")]
        public ActionResult Index()
        {
            var clients = _bus.ExecuteQuery(new GetAllClientsForOrganization(OrganizationId));

            return View(clients);
        }

        [HttpGet]
        [Route("client/{id}")]
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
        public ActionResult Create([Bind(Exclude = "Id")] ClientModel client)
        {
            var cmd = _mapper.Map<RegisterNewClientCommand>(client);

            _bus.ExecuteCommand(cmd);

            Notify(new SuccessMessage("Client successfully registered."));

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("client/edit/{id}")]
        [HandleValidationErrors]
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