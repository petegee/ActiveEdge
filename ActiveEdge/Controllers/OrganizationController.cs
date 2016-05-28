using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using ActiveEdge.Models.Organization;
using AutoMapper;
using Domain.Context;
using Domain.Model;
using Domain.Query;
using MediatR;
using Microsoft.Ajax.Utilities;

namespace ActiveEdge.Controllers
{
    public class OrganizationController : ControllerBase
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly MapperConfiguration _mapperConfiguration;

        public OrganizationController(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator, MapperConfiguration mapperConfiguration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
            _mapperConfiguration = mapperConfiguration;
        }

        // GET: Organization
        public ActionResult Index()
        {
            var organizations =
                _mediator.Send(new FindAllOrganizations()).ProjectToList<OrganizationModel>(_mapperConfiguration);

            return View(organizations);
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            var model = new OrganizationModel();
            
            model.Clinics = new List<ClinicModel>() {new ClinicModel () };
            return View(model);
        }

        // POST: Organization/Create
        [HttpPost]
        public JsonResult Create(OrganizationModel organizationModel)
        {
            var organization = _mapper.Map<Organization>(organizationModel);

            _dbContext.Organizations.Add(organization);

            _dbContext.SaveChanges();

            return Json(new
            {
                redirectUrl = Url.Action("Index", "Organization"),
                isRedirect = true
            });
            
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
