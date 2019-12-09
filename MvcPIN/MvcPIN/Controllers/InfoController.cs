using Microsoft.AspNetCore.Mvc;

namespace MvcPIN.Web.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}