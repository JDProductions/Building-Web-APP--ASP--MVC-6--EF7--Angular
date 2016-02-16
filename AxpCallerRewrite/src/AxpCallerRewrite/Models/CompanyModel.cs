using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AxpCallerRewrite.Models
{
    public class CompanyModel
    {

        [XmlIgnore]
        public string EnvironmentLevel { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string CompanyType { get; set; }

    }
}
