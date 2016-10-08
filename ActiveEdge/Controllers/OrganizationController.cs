using System.Collections.Generic;
using System.Web.Mvc;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Organization;
using ActiveEdge.Read.Query.Organization;
using AutoMapper;
using Domain.Command;
using Domain.Context;
using Shared;

namespace ActiveEdge.Controllers
{
    [AuthorizeRoles(Roles.SystemAdministrator)]
    public class OrganizationController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public OrganizationController(IMapper mapper, IBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("organizations")]
        public ActionResult Index()
        {
            var organizations = _bus.ExecuteQuery(new FindAllOrganizations());

            return View(organizations);
        }

        [HttpGet]
        [Route("organization/{id}")]
        public ActionResult Details(int id)
        {
            var model = _bus.ExecuteQuery(new GetOrganization(id));

            return View(model);
        }

        [HttpGet]
        [Route("organization/new")]
        public ActionResult Create()
        {
            var model = new OrganizationModel {Clinics = new List<ClinicModel> {new ClinicModel()}};

            return View(model);
        }

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
            var model = _bus.ExecuteQuery(new GetOrganization(id));

            return View(model);
        }

        [HttpPost]
        [Route("organization/edit/{id}")]
        public ActionResult Edit(OrganizationModel model)
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
        [Route("organization/delete/{id}")]
        public ActionResult Delete(OrganizationModel model)
        {
            _bus.ExecuteCommand(new DeleteOrganizationCommand(model.Id));

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