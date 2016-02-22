using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace AxpCallerRewrite.Models
{
    public class CompanyModel
    {

        [XmlIgnore]
        public string EnvironmentLevel { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip Code is Required")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Phone Number is Not Valid")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$", ErrorMessage = "Email is Not valid")]
        public string Email { get; set; }

        [RegularExpression("^\\d{10}$", ErrorMessage = "Fax Nuber is Not Valid")]
        public string Fax { get; set; }
        public string CompanyType { get; set; }

    }
}
