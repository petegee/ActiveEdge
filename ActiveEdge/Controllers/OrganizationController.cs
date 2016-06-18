using System.Collections.Generic;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Models.Organization;
using AutoMapper;
using Domain;
using Domain.Command;
using Domain.Context;
using Domain.Query.Organization;

namespace ActiveEdge.Controllers
{
    [AuthorizeRoles(Roles.SystemAdministrator)]
    public class OrganizationController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        public OrganizationController(IMapper mapper, IBus bus, MapperConfiguration mapperConfiguration)
        {
            _mapper = mapper;
            _bus = bus;
            _mapperConfiguration = mapperConfiguration;
        }

        [HttpGet]
        [Route("organizations")]
        public ActionResult Index()
        {
            var organizations =
                _bus.ExecuteQuery(new FindAllOrganizations()).ProjectToList<OrganizationModel>(_mapperConfiguration);

            return View(organizations);
        }

        [HttpGet]
        [Route("organization/{id}")]
        public ActionResult Details(int id)
        {
            var model = _bus
                .ExecuteQuery(new GetOrganization(id))
                .ProjectToSingle<OrganizationModel>(_mapperConfiguration);

            return View(model);
        }

        [HttpGet]
        [Route("organization/new")]
        public ActionResult Create()
        {
            var model = new OrganizationModel {Clinics = new List<ClinicModel> {new ClinicModel()}};

            return View(model);
        }

        // POST: Organization/Create
        [HttpPost]
        [Route("organization/new")]
        public JsonResult Create(OrganizationModel organizationModel)
        {
            var command = _mapper.Map<CreateNewOrganizationCommand>(organizationModel);

            var organizationId = _bus.ExecuteCommand(command);

            return Json(new
            {
                redirectUrl = Url.Action("CreateForOrganization", "Users", new {id = organizationId}),
                isRedirect = true
            });
        }

        [HttpGet]
        [Route("organization/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var model = _bus
                .ExecuteQuery(new GetOrganization(id))
                .ProjectToSingle<OrganizationModel>(_mapperConfiguration);

            return View(model);
        }

        [HttpPost]
        [Route("organization/edit/")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("organization/delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("organization/delete/")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _bus.ExecuteCommand(new DeleteOrganizationCommand(id));

            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}