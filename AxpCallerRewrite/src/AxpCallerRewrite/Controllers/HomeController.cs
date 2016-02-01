using System;
using System.Collections.Generic;
using System.Text;
using AxpCallerRewrite.Concrete;
using AxpCallerRewrite.Interfaces;
using AxpCallerRewrite.Models;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
namespace AxpCallerRewrite.Controllers
{

    public class HomeController : Controller
    {
        private readonly IConfigHelper _configHelper;

        public HomeController(IConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }


        public IActionResult Index(string fileName, string fileType, int fileSize)
        {
            ViewBag.Environments = _configHelper.GetEnvironments();
            var model = new HomeViewModel { Environment = "DEV" };
            Console.Write(fileName);
            return View();
        }

        public IActionResult ProcessFile()
        {
            var input = new FileInputModel();


            using (System.IO.StreamReader reader = new System.IO.StreamReader(Request.Form.Files[0].OpenReadStream()))
            {
                var content = reader.ReadToEnd();

                // Deserialzation
                // Taking string of Json, taking out key value maps and binding it to a model we defined
                input = JsonConvert.DeserializeObject<FileInputModel>(content);

                return Json(new { companyIds = input.Companies, template = input.Axp, environment = input.Environment });
            }
        }

        public IActionResult SendAxpTemplate(string companyIds, string axpTemplate)
        {
            var input = new FileInputModel();
            // Send Axp Template
            SendTemplate template = new SendTemplate();
            ParseHelper parser = new ParseHelper();
            parser.SplitCompanyIDs(companyIds);

            template.SendAxpTemplate(parser.SplitCompanyIDs(companyIds), axpTemplate);
            var test = "";
            return Json(new { success = true });
        }

        public IActionResult CategoryChosen(int environmentLevel)
        {
            //ViewBag.messageString = environmentLevel;
            //string Development = HttpRequestMe
            return View("Index");
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
