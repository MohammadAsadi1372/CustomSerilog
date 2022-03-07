using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace testSerilogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger ;

        private readonly Serilog.ILogger _log = Log.ForContext<WeatherForecastController>();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _log.ForContext("MohammadId", "MohammadData - 1 !!!!!", true)
                .ForContext("MohammadString", "MohammadString @@@!!!!!!").Information("asdasbdajsbdjasbdj11100000555");
          
            //---------------------------------------------------------------------------------------------------------------

            /*   IConfigurationRoot config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
               var log = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
               log.ForContext("MohammadId", "MohammadData - 3", true).Warning("asdasbdajsbdjasbdj11100000555");
               log.ForContext("MohammadId", "MohammadData - 5", true).Error("asdasbdajsbdjasbdj11100000555");*/


            //----------------------------------------------------------------------------------------------------------------


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
