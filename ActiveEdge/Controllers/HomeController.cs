using System.Web.Mvc;
using ActiveEdge.Read.Model.Shared;
using Domain.Context;
using Marten;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IDocumentStore _store;
        private readonly DatabaseInitializer _dbInitializer;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public HomeController(IDocumentStore store, DatabaseInitializer dbInitializer)
        {
            _store = store;
            _dbInitializer = dbInitializer;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome to the Active Edge Dashboard ";
            //ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";

            return View();
        }

        [HttpGet]
        [Route("clean")]
        public ActionResult Clean()
        {
            _store.Advanced.Clean.DeleteAllDocuments();
            _store.Advanced.Clean.DeleteAllEventData();
            //CompletelyRemoveAll();

            _dbInitializer.Seed();

           Notify<WarningMessage>("Database Cleansed");

            return RedirectToAction("Index");
        }

      
    }
}