using System.Web.Mvc;

namespace ListingsManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Post");
        }
    }
}