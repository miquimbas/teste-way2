namespace OpenWeatherAPI.Models
{
    public class Daily
    {
        public Temp temp { get; set; }
        public long dt { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
    }
}