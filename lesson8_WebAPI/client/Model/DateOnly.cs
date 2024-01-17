using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class DateOnly {
    /// <summary>
    /// Gets or Sets Year
    /// </summary>
    [DataMember(Name="year", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "year")]
    public int? Year { get; set; }

    /// <summary>
    /// Gets or Sets Month
    /// </summary>
    [DataMember(Name="month", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "month")]
    public int? Month { get; set; }

    /// <summary>
    /// Gets or Sets Day
    /// </summary>
    [DataMember(Name="day", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "day")]
    public int? Day { get; set; }

    /// <summary>
    /// Gets or Sets DayOfWeek
    /// </summary>
    [DataMember(Name="dayOfWeek", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dayOfWeek")]
    public DayOfWeek DayOfWeek { get; set; }

    /// <summary>
    /// Gets or Sets DayOfYear
    /// </summary>
    [DataMember(Name="dayOfYear", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dayOfYear")]
    public int? DayOfYear { get; set; }

    /// <summary>
    /// Gets or Sets DayNumber
    /// </summary>
    [DataMember(Name="dayNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "dayNumber")]
    public int? DayNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DateOnly {\n");
      sb.Append("  Year: ").Append(Year).Append("\n");
      sb.Append("  Month: ").Append(Month).Append("\n");
      sb.Append("  Day: ").Append(Day).Append("\n");
      sb.Append("  DayOfWeek: ").Append(DayOfWeek).Append("\n");
      sb.Append("  DayOfYear: ").Append(DayOfYear).Append("\n");
      sb.Append("  DayNumber: ").Append(DayNumber).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
