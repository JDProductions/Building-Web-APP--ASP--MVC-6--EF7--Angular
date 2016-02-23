using System.ComponentModel.DataAnnotations;

namespace AxpCallerRewrite.Models
{
    public class FeatureModel
    {
        [Required(ErrorMessage = "Company IDs are Required")]
        [RegularExpression("^([0-9a-zA-Z]{3}[-]){2}[0-9a-zA-Z]{3}([;,]([0-9a-zA-Z]{3}[-]){2}[0-9a-zA-Z]{3})*$", ErrorMessage = "Company IDs are Not Valid")]
        public string CompanyIds { get; set; }
        public int FeatureId { get; set; }
        public int OemId { get; set; }
        public int ProdId { get; set; }
        public string EnvironmentLevel { get; set; }
    }
}
