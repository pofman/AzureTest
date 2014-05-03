using System.Web.Mvc;
using NailsFramework.UserInterface;

namespace AzureTest.Client.Controllers
{
    public class HomeController : NailsController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
