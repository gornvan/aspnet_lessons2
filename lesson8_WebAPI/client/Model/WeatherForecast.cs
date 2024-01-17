using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IO.Swagger.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or Sets TemperatureC
        /// </summary>
        [DataMember(Name = "temperatureC", EmitDefaultValue = false)]
        [JsonPropertyName("temperatureC")]
        public int? TemperatureC { get; set; }

        /// <summary>
        /// Gets or Sets TemperatureF
        /// </summary>
        [DataMember(Name = "temperatureF", EmitDefaultValue = false)]
        [JsonPropertyName("temperatureF")]
        public int? TemperatureF { get; set; }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [JsonPropertyName("summary")]
        public string Summary { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WeatherForecast {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  TemperatureC: ").Append(TemperatureC).Append("\n");
            sb.Append("  TemperatureF: ").Append(TemperatureF).Append("\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
