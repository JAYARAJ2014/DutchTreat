using System;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly DutchContext _context;

        public AppController(IEmailService emailService, DutchContext context)
        {
            _emailService = emailService;
            _context = context;
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
            var results = _context.Products.OrderBy(p=>p.Category).ToList();
            return View(results);
        }

    }
}