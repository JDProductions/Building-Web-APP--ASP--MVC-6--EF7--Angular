using AxpCaller.ViewModels;
using Microsoft.AspNet.Mvc;

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
            return View();
            
            
        }

    }

}