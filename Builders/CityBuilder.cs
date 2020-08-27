using NPOI.XSSF.UserModel;
using OpenWeatherAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherAPI.Builders
{
    public class CityBuilder
    {
        private int id;
        private string name;
        private double longitude;
        private double latitude;

        public CityBuilder withId(int id) 
        {
            this.id = id;
            return this;
        }

        public CityBuilder withName(string name)
        {
            this.name = name;
            return this;
        }

        public CityBuilder withLongitude(double longitude)
        {
            this.longitude = longitude;
            return this;
        }

        public CityBuilder withLatitude(double latitude)
        {
            this.latitude = latitude;
            return this;
        }

        public City build() 
        {
            City city = new City();
            city.id = id;
            city.name = name;
            city.latitude = latitude;
            city.longitude = longitude;
            return city;
        }
    }
}
