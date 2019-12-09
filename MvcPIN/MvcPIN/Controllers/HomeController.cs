using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcPIN.Models;
using MvcPIN.Services.Contracts;
using MvcPIN.Web.Models;

namespace MvcPIN.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPinService pinService;

        public HomeController(IPinService pinService)
        {
            this.pinService = pinService;
        }

        public IActionResult Index()
        {
            var pins = this.pinService.GetAllPins<PinViewModel>();

            var model = new PinsViewModel
            {
                Pins = pins
            };

            return this.View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
