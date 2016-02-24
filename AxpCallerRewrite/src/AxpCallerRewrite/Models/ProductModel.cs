using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Models
{
    public class ProductModel
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductLevelId { get; set; }
        public string EnvironmentLevel { get; set; }
    }
}
