using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenWeatherAPI.Database;
using OpenWeatherAPI.Helpers;
using OpenWeatherAPI.Models;
using OpenWeatherAPI.Repositories;
using OpenWeatherAPI.Schedulers;
using System;

namespace OpenWeatherAPI
{
    public class Startup
    {
        private const int Interval = 15;

        private static WeatherRepository repository = new WeatherRepository();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InMemoryDatabase.Initialize();

            WeatherScheduler.ScheduleTaskByMinutes(
                () => {
                    Weather florianopolisWeather = repository.getWeatherBy(TimeHelper.convertToUnixTimeStamp(DateTime.Now), InMemoryDatabase.florianopolis);
                    Weather curitibaWeather = repository.getWeatherBy(TimeHelper.convertToUnixTimeStamp(DateTime.Now), InMemoryDatabase.curitiba);
                    Weather portoAlegreWeather = repository.getWeatherBy(TimeHelper.convertToUnixTimeStamp(DateTime.Now), InMemoryDatabase.portoAlegre);
                },
                Interval
            );
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
