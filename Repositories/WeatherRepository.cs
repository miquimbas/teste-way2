using Newtonsoft.Json;
using OpenWeatherAPI.Database;
using OpenWeatherAPI.Dtos;
using OpenWeatherAPI.Helpers;
using OpenWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace OpenWeatherAPI.Repositories
{
    public class WeatherRepository
    {
        public Weather getWeatherBy(double timestamp, City city) 
        {
            string url = $"http://api.openweathermap.org/data/2.5/onecall/timemachine?lat={city.latitude}&lon={city.longitude}&dt={timestamp}&appid=789ebb9029bd4dcf9bb5face1eb6afd9";            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<Weather>(reader.ReadToEnd());
            }
        }

        public List<Weather> FindWeatherLocally(FindWeatherLocallyDTO dto)
        {            
            return InMemoryDatabase.weatherList.FindAll(weather => isValid(weather, dto));
        }

        private Boolean isValid(Weather weather, FindWeatherLocallyDTO dto)
        {
            return isCityValid(weather.city.name, dto.cityName)
                & isDateInRange(dto.startDate, dto.endDate, TimeHelper.convertToDateTime(weather.current.dt));;
        }

        private Boolean isCityValid(string cityName1, string cityName2) 
        {
            if (String.IsNullOrEmpty(cityName1) || String.IsNullOrEmpty(cityName2)) return true;
            return cityName1.Equals(cityName2);
        }

        private Boolean isDateInRange(DateTime startDate, DateTime endDate, DateTime dateToCompare) 
        {
            if (startDate == null || endDate == null) return true;
            return startDate.Date.CompareTo(dateToCompare.Date) <= 0 & endDate.Date.CompareTo(dateToCompare.Date) >= 0;
        }
    }
}
