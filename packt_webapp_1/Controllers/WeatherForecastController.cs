using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace packt_webapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {

            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching","koud","zeer koud", "zeer warm","-40","500", "-900"

        };


        private int bereken1(int getal1, int getal2)
        {
<<<<<<< .merge_file_a12380
            return getal1 / getal2;
        }

=======
            return getal1 + getal2;//TestBranch2 //som
        }

        private int berekenVerschil(int getal1, int getal2)
        {
            return getal1 - getal2;//TestBranch2 //verschil
        }

        private int berekenProdukt(int getal1, int getal2)
        {
            return getal1 * getal2;//TestBranch2 //produkt
        }
>>>>>>> .merge_file_a16492

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
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
