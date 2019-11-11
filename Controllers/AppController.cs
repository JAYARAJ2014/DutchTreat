using System;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Repository;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IDutchRepository _repository;

        public AppController(IEmailService emailService, IDutchRepository repository)
        {
            _emailService = emailService;
            _repository =repository;
        }
        public IActionResult Index()
        {
            var result =_repository.GetAllProducts();
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
                ViewBag.UserMessage = "Email has been send";
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

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }

    }
}