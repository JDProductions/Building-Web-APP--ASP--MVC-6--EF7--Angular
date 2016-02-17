using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Models
{
    public class FeatureModel
    {
        public int FeatureId { get; set; }
        public int OemId { get; set; }
        public int StatusId { get; set; }
        public int DirtyFlag { get; set; }
        public int ProdId { get; set; }
        public string EnvironmentLevel { get; set; }
    }
}
