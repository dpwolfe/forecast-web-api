namespace hw.Models
{
    public class Forecast
    {
        // database unique id
        public int Id { get; set; }

        // float or double?
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float Temperature { get; set; }

        // validation of either celsius or fahrenheit is used
        public ETemperatureUnit TemperatureUnit { get; set; } = ETemperatureUnit.Celcius;
    }
}