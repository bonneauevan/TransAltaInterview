using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TransAltaInterview.Models
{
    public class MontlySummary
    {
        [JsonPropertyName("coldestday")]
        [JsonProperty("coldestday")]
        [Display(Name = "ColdestDay")]
        public int ColdestDay { get; set; }

        [JsonPropertyName("coldesttemp")]
        [JsonProperty("coldesttemp")]
        [Display(Name = "ColdestTemp")]
        public double ColdestTemp { get; set; }

        [JsonPropertyName("hottestday")]
        [JsonProperty("hottestday")]
        [Display(Name = "HottestDay")]
        public int HottestDay { get; set; }

        [JsonPropertyName("hottesttemp")]
        [JsonProperty("hottesttemp")]
        [Display(Name = "HottestTemp")]
        public double HottestTemp { get; set; }

        [JsonPropertyName("totalpercipitation")]
        [JsonProperty("totalpercipitation")]
        [Display(Name = "TotalPercipitation")]
        public double TotalPercipitation { get; set; }

        [JsonPropertyName("maxgustdays")]
        [JsonProperty("maxgustdays")]
        [Display(Name = "MaxGustDays")]
        public int MaxGustDays { get; set; }
    }
}
