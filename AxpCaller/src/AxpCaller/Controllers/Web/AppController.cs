using AxpCaller.Controllers.ViewLogicControllers;
using AxpCaller.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace AxpCaller.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       //[HttpPost]
        public IActionResult Activate (ActivateViewModel aModel, string fileText)
        {
            List<string> companyIdList = new List<string>();
            CompanyIDSplitterController splitter = new CompanyIDSplitterController();
            companyIdList = splitter.SplitCompanyIDs(aModel);

            //ViewBag.CompanyID = companyIdList;

            ViewBag.AxpTemplateArea = fileText;
            ViewBag.CompanyID = fileText;

            return View();


            //return View();


        }

        public IActionResult UploadCompanyID(ActivateViewModel aModel, string fileText)
        {
            string textAreaCompanyID = Request.Form["CompanyID"];
            

            return RedirectToAction("Activate", "App", new { fileText = fileText });
        }

        [HttpPost]
        public IActionResult UploadFile(ActivateViewModel aModel2)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(Request.Form.Files[0].OpenReadStream()))
            {
               
                string textArea = Request.Form["AxpTemplate"];
                var content = reader.ReadToEnd();

                var fileText = content.ToString();
                return RedirectToAction("Activate", "App", new { fileText = fileText });
            }

        }

    }

}