using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        IMailService mailService;
        public AppController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            if(string.IsNullOrWhiteSpace(contactViewModel.Email))
            {
                ModelState.AddModelError("", "Configuration Error");
            }

            if(mailService.SendMessage(new MailDto() { Subject = $"Content Page name {contactViewModel.Name} and mail {contactViewModel.Email}", Body=contactViewModel.Message}))
            {
                ModelState.Clear();
                ViewBag.Message = "Mail Send. Thanks!";
            }

            return View();
        }
    }
}
