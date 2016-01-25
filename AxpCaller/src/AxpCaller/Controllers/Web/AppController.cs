using AxpCaller.Controllers.ViewLogicControllers;
using AxpCaller.ViewModels;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Web;

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

        [HttpPost]
        public IActionResult UploadFile()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(Request.Form.Files[0].OpenReadStream()))
            {
                var content = reader.ReadToEnd();
            }
            return View();
        }

    }

}