using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherStation
{
    class OpenWeather
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "dt")]
        public int Time { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string CityName { get; set; }

        [JsonProperty(PropertyName = "coord")]
        public Coord Coord { get; set; }

        [JsonProperty(PropertyName = "sys")]
        public Sys Sys { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "main")]
        public WeatherData WeatherData { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public WindData Wind { get; set; }

        [JsonProperty(PropertyName = "clouds")]
        public CloudsData Clouds { get; set; }

        [JsonProperty(PropertyName = "cod")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }

    public class Coord
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
    }

    public class Sys
    {
        [JsonProperty(PropertyName = "message")]
        public double Message { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty(PropertyName = "sunset")]
        public int Sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
    }

    public class WeatherData
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public double MinTemperature { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public double MaxTemperature { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }

        [JsonProperty(PropertyName = "sea_level")]
        public double SeaLevelPressure { get; set; }

        [JsonProperty(PropertyName = "grnd_level")]
        public double GroundLevelPressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
    }

    public class WindData
    {
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        [JsonProperty(PropertyName = "deg")]
        public double Direction { get; set; }
    }

    public class CloudsData
    {
        [JsonProperty(PropertyName = "all")]
        public int Cloudiness { get; set; }
    }
}
