/* Home controller, the only information here is that it takes us to the home page */

using System.Web.Mvc;

namespace SportsSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}