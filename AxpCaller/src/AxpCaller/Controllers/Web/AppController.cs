using System.Collections.Generic;
using AxpCaller.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Linq;
using AxpCaller.Controllers.ViewLogicControllers;

namespace AxpCaller.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       //[HttpPost]
        public IActionResult Activate (ActivateViewModel aModel)
        {
            List<string> companyIdList = new List<string>();
            CompanyIDSplitterController splitter = new CompanyIDSplitterController();
            companyIdList = splitter.SplitCompanyIDs(aModel);
            return View();


            //return View();


        }

    }

}