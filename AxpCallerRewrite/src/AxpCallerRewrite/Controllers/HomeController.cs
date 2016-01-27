using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Http;
using Newtonsoft.Json;

namespace AxpCallerRewrite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChosen(int environmentLevel)
        {
            //ViewBag.messageString = environmentLevel;
            //string Development = HttpRequestMe
            return View("Index");
        }

        // bound button click to this method
        // 
        public int GetChosenEnvLevel(int environmentLevel)
        {
            //ViewBag.messageString = environmentLevel;
            //string Development = HttpRequestMe
            // check environment level, make new string to return link

            JsonSerializer serializer = new JsonSerializer();

            switch (environmentLevel)
            {
                // Development
                case 0:
                    // create string for textbox
                    string linkText = "http://devapp1/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork";
                    ViewBag.labelEnvironment = linkText;
                    break;
                // Qa
                case 1:
                    string linkQA = "http://devapp1/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork";
                    break;
                // New QA
                case 2:
                    string linkNewQA = "http://devapp1/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork";
                    break;
               // Production
                case 3:
                    string linkProduction = "http://devapp1/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork";
                    break;
            }

            return environmentLevel;
        }

        public ActionResult SelectCategory()
        {

            //List<SelectListItem> items = new List<SelectListItem>();

            //items.Add(new SelectListItem { Text = "Development", Value = "0" });

            //items.Add(new SelectListItem { Text = "QA", Value = "1" });

            //items.Add(new SelectListItem { Text = "New QA", Value = "2", Selected = true });

            //items.Add(new SelectListItem { Text = "Production", Value = "3" });

            //ViewBag.MovieType = items;

            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
