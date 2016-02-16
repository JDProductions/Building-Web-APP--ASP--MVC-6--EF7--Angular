using System.Xml.Serialization;
using System;
using AxpCallerRewrite.Concrete;
using AxpCallerRewrite.Interfaces;
using AxpCallerRewrite.Models;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System.IO;
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
                    var test = "";

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

        public IActionResult AxpRevamp()
        {
            ViewBag.CompanyTypes = new SelectList(new List<SelectListItem>(), "", "");//_legacyHelper.GetCompanyData();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult CreateCompany(CompanyModel company)
        {
            //Convert company to XML string
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(company.GetType());
            serializer.Serialize(writer, company);

            string xmlString = writer.ToString();
            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();
            // Send Create Company Template to Server
           template.SendAxpTemplate(xmlString, company.EnvironmentLevel);
           //template.SendAxpTemplate(xmlString, environment.EnvironmentLevel);
           // return RedirectToAction("Axprevamp");
            return Json(new { success = true });
        }
    }
}
