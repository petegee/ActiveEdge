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

        // GET: Organization
        public ActionResult Index()
        {
            var organizations =
                _bus.ExecuteQuery(new FindAllOrganizations()).ProjectToList<OrganizationModel>(_mapperConfiguration);

            return View(organizations);
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            var model = _bus
                .ExecuteQuery(new GetOrganization(id))
                .ProjectToSingle<OrganizationModel>(_mapperConfiguration);

            return View(model);
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            var model = new OrganizationModel {Clinics = new List<ClinicModel> {new ClinicModel()}};

            return View(model);
        }

        // POST: Organization/Create
        [HttpPost]
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

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _bus
                .ExecuteQuery(new GetOrganization(id))
                .ProjectToSingle<OrganizationModel>(_mapperConfiguration);

            return View(model);
        }

        // POST: Organization/Edit/5
        [HttpPost]
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

        // GET: Organization/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organization/Delete/5
        [HttpPost]
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