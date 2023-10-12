using System.Text.Json.Serialization;

namespace hw.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ETemperatureUnit
    {
        Celcius = 1,
        Fahrenheit = 2
    }
}