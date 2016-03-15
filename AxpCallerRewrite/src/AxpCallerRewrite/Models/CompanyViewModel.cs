using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Models
{
    public class CompanyViewModel
    {
        public SelectList States { get; set; }
        public SelectList CompanyTypes { get; set; }
        public SelectList Countries { get; set; }
        public CompanyModel Company { get; set; }
    }
}
