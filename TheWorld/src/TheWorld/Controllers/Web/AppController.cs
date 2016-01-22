using System;
using Microsoft.AspNet.Mvc;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        // Default Method - When a request comes into the root of the website, this is the method is to be called when that request comes into the root
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
        public IActionResult Contact (ContactViewModel model)
        {
            return View();
        }

    }

}