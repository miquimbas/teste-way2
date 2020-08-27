using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenWeatherAPI.Database;
using OpenWeatherAPI.Dtos;
using OpenWeatherAPI.Helpers;
using OpenWeatherAPI.Models;
using OpenWeatherAPI.Repositories;
using OpenWeatherAPI.Schedulers;

namespace OpenWeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]/{cityName}/{startDate}/{endDate}")]
    
    public class WeatherForecastController : ControllerBase
    {
        private static WeatherRepository repository = new WeatherRepository();

        [HttpGet]
        public string Get(string cityName, long startDate, long endDate)  
        {
            FindWeatherLocallyDTO dto = new FindWeatherLocallyDTO();
            dto.startDate = TimeHelper.convertToDateTime(startDate/1000);
            dto.endDate = TimeHelper.convertToDateTime(endDate / 1000);
            dto.cityName = cityName;

            List<Weather> weatherList = repository.FindWeatherLocally(dto);

            Console.WriteLine("Start Filtered List");

            String output = "";
            weatherList.ForEach(weather => output += weather.city.name + ":" + weather.current.temperatureInCelsius() + "\n");
            Console.WriteLine("End Filtered List");

            return output;
        }     
    }
}
