using System.Collections.Generic;

namespace OpenWeatherAPI.Models {
    public class Weather {
        public Current current { get; set; }
        public City city { get; set; }
    }
}

