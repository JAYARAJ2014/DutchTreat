using System;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IEmailService _emailService;

        public AppController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _emailService.SendEmail(model.Email, model.Subject, model.Message);
            }
            else
            {

            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

    }
}