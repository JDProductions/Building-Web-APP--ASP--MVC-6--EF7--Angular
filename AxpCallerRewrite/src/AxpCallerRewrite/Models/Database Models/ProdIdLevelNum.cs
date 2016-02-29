using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Models.Database_Models
{
    public class ProdIdLevelNum
    {
        public int LegacyProductID { get; set; }
        public string LegacyProductName { get; set; }
        public int ProductLevelNumber { get; set; }
        public string ProductLevelKey { get; set; }
    }
}
