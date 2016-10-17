using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Organization;
using AutoMapper;
using Domain.Context;
using Marten;
using Shared;

namespace ActiveEdge.Controllers
{
    [AuthorizeRoles(Roles.SystemAdministrator)]
    public class OrganizationController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        public OrganizationController(IMapper mapper, IDocumentSession session, IBus bus, ILoggedOnUser loggedOnUser)
            : base(loggedOnUser)
        {
            _mapper = mapper;
            _session = session;
            _bus = bus;
        }

        [HttpGet]
        [Route("organizations")]
        public async Task<ActionResult> Index()
        {
            var organizations = await _session.Query<OrganizationModel>().ToListAsync();

            return View(organizations);
        }

        [HttpGet]
        [Route("organization/{id}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _session.LoadAsync<OrganizationModel>(id);

            return View(model);
        }

        [HttpGet]
        [Route("organization/new")]
        public ActionResult Create()
        {
            var model = new OrganizationModel();

            model.Clinics.Add(new ClinicModel());
            
            return View(model);
        }

        //[HttpPost]
        //[Route("organization/new")]
        //public JsonResult Create(OrganizationModel organizationModel)
        //{
        //    var command = _mapper.Map<CreateNewOrganization>(organizationModel);

        //    var organizationId = _bus.ExecuteCommand(command);

        //    return Json(new
        //    {
        //        redirectUrl = Url.Action("CreateForOrganization", "Users", new {id = organizationId}),
        //        isRedirect = true
        //    });
        //}

        [HttpGet]
        [Route("organization/edit/{id}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _session.LoadAsync<OrganizationModel>(id);

            ViewBag.url = Url.RouteUrl("UpdateOrganizationApi", new {httproute = true, organizationId = id});
            return View(model);
        }

        //[HttpPost]
        //[Route("organization/edit/{id}")]
        //public ActionResult Edit(OrganizationModel model)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpGet]
        [Route("organization/delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        //        return RedirectToAction("Index");
        //        // TODO: Add delete logic here
        //    {

        //    try
        //    _bus.ExecuteCommand(new DeleteOrganizationCommand(model.Id));
        //{
        //public ActionResult Delete(OrganizationModel model)
        //[Route("organization/delete/{id}")]

        //[HttpPost]
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}