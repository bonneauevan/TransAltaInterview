using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TransAltaInterview.Models
{
    public class WeatherRecord
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        [Display(Name = "Id")]
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonProperty("timestamp")]
        [Display(Name = "TimeStamp")]
        [Required]
        public string TimeStamp { get; set; }

        [JsonPropertyName("windspeed")]
        [JsonProperty("windspeed")]
        [Display(Name = "WindSpeed")]
        public int WindSpeed { get; set; }

        [JsonPropertyName("windspeedgust")]
        [JsonProperty("windspeedgust")]
        [Display(Name = "WindSpeedGust")]
        public int WindSpeedGust { get; set; }

        [JsonPropertyName("temperature")]
        [JsonProperty("temperature")]
        [Display(Name = "Temperature")]
        public int Temperature { get; set; }

        [JsonPropertyName("humidity")]
        [JsonProperty("humidity")]
        [Display(Name = "Humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("theoreticalpower")]
        [JsonProperty("theoreticalpower")]
        [Display(Name = "TheoreticalPower")]
        public float TheoreticalPower { get; set; }
    }
}
