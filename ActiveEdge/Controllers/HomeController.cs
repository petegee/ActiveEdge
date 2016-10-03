using System.Web.Mvc;
using Marten;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDocumentSession _session;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public HomeController(IDocumentSession session)
        {
            _session = session;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome to the Active Edge Dashboard ";
            //ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";

            return View();
        }

      
    }
}