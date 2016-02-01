using System;
using System.Collections.Generic;
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
                string textArea = Request.Form["fileUploadForm"];
                var content = reader.ReadToEnd();
                List<string> CompanyIdList = new List<string>();
                CompanyIdList.Add(content);

                // Deserialzation
                // Taking string of Json, taking out key value maps and binding it to a model we defined
                input = JsonConvert.DeserializeObject<FileInputModel>(content);

                var model = new FileInputModel();
                ParseHelper parser = new ParseHelper();
                var companyIDList = parser.SplitCompanyIDs(input.Companies);
             
                //var axpTemplate = parser.SplitCompanyIDs(input.Axp);
                var test = "";
                

                // Seperate template from company ids by using a model or 


            }

            return Json(new { companyIds = input.Companies, template = input.Axp, environment = input.Environment });
                
        }

        public IActionResult CategoryChosen(int environmentLevel)
        {
            //ViewBag.messageString = environmentLevel;
            //string Development = HttpRequestMe
            return View("Index");
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
