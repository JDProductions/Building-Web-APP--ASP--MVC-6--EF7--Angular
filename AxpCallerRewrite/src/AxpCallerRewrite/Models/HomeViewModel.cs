using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;

namespace AxpCallerRewrite.Models
{
    public class HomeViewModel
    {
        public string Environment { get; set; }

        public string CompanyID { get; set; }

        public string AxpTempalte { get; set; }
        // File Object
        //public File file { get; set; }

    }
}
