using System;
using AxpCallerRewrite.Concrete;
using AxpCallerRewrite.Interfaces;
using AxpCallerRewrite.Models;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace AxpCallerRewrite.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILegacyHelper _legacyHelper;


        public HomeController(ILegacyHelper legacyHelper) // home controller depnds on legacyhelper now, injecting legacyhelper into your controller
        {
            // DEPENDENCY INJECTION
            //_configHelper = configHelper;
            _legacyHelper = legacyHelper;

        }


        public IActionResult Index(string fileName, string fileType, int fileSize)
        {

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
                try
                {
                    input = JsonConvert.DeserializeObject<FileInputModel>(content);

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                return
                        Json(new { companyIds = input.Companies, template = input.Axp, environment = input.Environment });
            }
        }

        public IActionResult SendAxpTemplate(string companyIds, string axpTemplate, string environmentLevel)
        {
            var input = new FileInputModel();
            // Send Axp Template
            SendTemplate template = new SendTemplate();
            ParseHelper parser = new ParseHelper();
            var CompanyIDTest = parser.SplitCompanyIDs(companyIds);


            template.SendAxpTemplate(CompanyIDTest, axpTemplate, environmentLevel);
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

        public IActionResult AxpRevamp()
        {
            PrepareAxpRevamp();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyModel company)
        {
            
            if(ModelState.IsValid)
            {
                _legacyHelper.CreateCompany(company);
                SendTemplate template = new SendTemplate();

                return Ok();
            }
            else
            {
                PrepareAxpRevamp();
                return PartialView("_Company", company);
            }
        }

        [HttpPost]
        public IActionResult ActivateFeature(FeatureModel feature)
        {
            if (ModelState.IsValid)
            {
                _legacyHelper.ActivateFeature(feature);

                return Ok();
            }
            else
            {
                PrepareAxpRevamp();
                return PartialView("_Feature", feature);
            }
        }

        [HttpPost]
        public IActionResult DeactivateFeature(FeatureModel feature)
        {
            if (ModelState.IsValid)
            {
                _legacyHelper.DeactivateFeature(feature);

                return Ok();
            }
            else
            {
                PrepareAxpRevamp();
                return PartialView("_Feature", feature);
            }
        }

        private void PrepareAxpRevamp()
        {
            ViewBag.States = _legacyHelper.GetStates();

            ViewBag.Countries = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "United States", Value = "US" },
                    new SelectListItem { Text = "Canada", Value = "CA" },
                    new SelectListItem { Text = "Mexico", Value = "MX" }
                }, "Value", "Text");

            ViewBag.Environments = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem { Value = "Dev" , Text = "Dev"  },
                    new SelectListItem { Value = "QA" , Text = "QA" },
                    new SelectListItem { Value = "Prod" , Text = "Prod"}
                }, "Value", "Text");

            ViewBag.CompanyTypes = _legacyHelper.GetCompanyData();

            ViewBag.OEMs = _legacyHelper.GetOEMs();

            ViewBag.Products = _legacyHelper.GetProducts();

            ViewBag.Features = _legacyHelper.GetFeatures();
        }
    }
}
