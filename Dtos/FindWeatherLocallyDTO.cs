using OpenWeatherAPI.Models;
using System;

namespace OpenWeatherAPI.Dtos
{
    public class FindWeatherLocallyDTO
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string cityName { get; set; }
    }
}
