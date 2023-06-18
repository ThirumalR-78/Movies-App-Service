using Microsoft.AspNetCore.Mvc;
using System;

namespace PocketCinemaAPIService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private readonly DBContextClass _dbContext;
        private IUserService _userService;

       /* public WeatherForecastController(DBContextClass dbContext)
        {
            _dbContext = dbContext;
        }*/
        public WeatherForecastController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
        /* public IEnumerable<WeatherForecast> Get()*/
        public AuthenticateResponse Get()
        {
            AuthenticateRequest model = new AuthenticateRequest{ Username = "test", Password = "test" };

            var response = _userService.Authenticate(model);
            return response;

          /*  return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}