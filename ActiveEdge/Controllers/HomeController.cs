using System.Web.Mvc;

namespace ActiveEdge.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
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