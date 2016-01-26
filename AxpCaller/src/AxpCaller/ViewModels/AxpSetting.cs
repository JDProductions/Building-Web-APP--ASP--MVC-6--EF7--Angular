using Newtonsoft.Json;

namespace AxpCaller.ViewModels
{
    public class AxpSetting
    {
        [JsonProperty(PropertyName = "environment")]
        public string Environment { get; set; }

        [JsonProperty(PropertyName = "companies")]
        public string Companies { get; set; }

        [JsonProperty(PropertyName = "axp")]
        public string Axp { get; set; }
    }
}
