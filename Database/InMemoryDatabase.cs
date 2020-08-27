using OpenWeatherAPI.Builders;
using OpenWeatherAPI.Helpers;
using OpenWeatherAPI.Models;
using OpenWeatherAPI.Repositories;
using System;
using System.Collections.Generic;

namespace OpenWeatherAPI.Database
{
    public class InMemoryDatabase
    {
        public static List<Weather> weatherList { get; set; }        
        public static City florianopolis { get; set; }
        public static City curitiba { get; set; }
        public static City portoAlegre { get; set; }

        public const string Florianopolis = "Florianópolis";

        private static WeatherRepository repository = new WeatherRepository();

        public static void Initialize() 
        {            
            florianopolis = new CityBuilder()
                .withId(1)
                .withName(Florianopolis)
                .withLatitude(-27.61)
                .withLongitude(-48.5)
                .build();

            curitiba = new CityBuilder()
                .withId(2)
                .withName("Curitiba")
                .withLatitude(-25.5)
                .withLongitude(-49.29)
                .build();

            portoAlegre = new CityBuilder()
                .withId(3)
                .withName("Porto Alegre")
                .withLatitude(-30.03)
                .withLongitude(-51.23)
                .build();

            weatherList = PopulateDataBaseFrom(florianopolis);
            weatherList.AddRange(PopulateDataBaseFrom(curitiba));
            weatherList.AddRange(PopulateDataBaseFrom(portoAlegre));
        }

        private static List<Weather> PopulateDataBaseFrom(City city)
        {
            List<Weather> weatherList = new List<Weather>();

            Weather todayWeather = repository.getWeatherBy(TimeHelper.convertToUnixTimeStamp(DateTime.Now), city);
            todayWeather.city = city;
            weatherList.Add(todayWeather);

            for (int index = 1; index <= 4; index = index + 1)
            {
                Weather weather = repository.getWeatherBy(TimeHelper.convertToUnixTimeStamp(DateTime.Now.AddDays(-(index))), city);
                weather.city = city;
                weatherList.Add(weather);
            }

            return weatherList;
        }
    }
}
