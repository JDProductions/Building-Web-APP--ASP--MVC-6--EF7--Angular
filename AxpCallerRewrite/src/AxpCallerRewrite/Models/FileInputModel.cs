using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AxpCallerRewrite.Models
{
    public class FileInputModel
    {
        [JsonProperty(PropertyName = "environment")]
        public string Environment { get; set; }

        [JsonProperty(PropertyName = "companies")]
        public string Companies { get; set; }

        [JsonProperty(PropertyName = "axp")]
        public string Axp { get; set; }
    }
}
