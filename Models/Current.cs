using OpenWeatherAPI.Helpers;

namespace OpenWeatherAPI.Models
{
    public class Current
    {
        public long dt { get; set; }

        public long temp { get; set; }

        public double temperatureInCelsius() 
        {
            return TemperatureHelper.convertToCelsius(temp);
        }
    }
}