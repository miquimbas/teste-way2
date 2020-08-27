using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherAPI.Helpers
{
    public class TemperatureHelper
    {
        public static double convertToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}
