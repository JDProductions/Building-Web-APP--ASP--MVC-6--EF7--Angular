using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Models
{
    public class ProductViewModel
    {
        public SelectList ProdIdLevelNum { get; set; }
        public ProductModel Product { get; set; }
    }
}
