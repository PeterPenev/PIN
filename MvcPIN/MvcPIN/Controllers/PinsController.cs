using Microsoft.AspNetCore.Mvc;
using MvcPIN.Services.Contracts;
using MvcPIN.Web.Models;
using MvcPIN.Web.Utils;

namespace MvcPIN.Web.Controllers
{
    public class PinsController : Controller
    {
        private readonly IPinService pinService;

        public PinsController(IPinService pinService)
        {
            this.pinService = pinService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckIfPinIsValid(PinViewModel model)
        {
            if (!this.ModelState.IsValid || model.Name == null)
            {
                model.MessageText = string.Format(WebConstants.EnterValidData, model.Name);

                return View(model);
            }

            var isSucceeded = this.pinService.isValidPin(model.Name);

            if (isSucceeded)
            {
                model.MessageText = string.Format(WebConstants.PinIsValid, model.Name);
                model.IsValid = true;

                return View(model);
            }
            else
            {
                model.MessageText = string.Format(WebConstants.PinIsNotValid, model.Name);

                return View(model);
            }
        }
    }
}