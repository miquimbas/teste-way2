using System;
using System.Threading;

namespace OpenWeatherAPI.Schedulers
{
    public class WeatherScheduler
    {
        public static void ScheduleTaskByMinutes(Action task, double interval)
        {
            var timer = new Timer(x =>
            {
                task.Invoke();
            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(interval));
        }
    }
}
