using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Models
{
    
    public class AxpCallerRewriteViewModel
    {
        public CompanyViewModel CompanyView { get; set; }
        public ProductViewModel ProductView { get; set; }
    }
}
