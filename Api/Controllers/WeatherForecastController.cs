using Microsoft.AspNetCore.Mvc;
using Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Api.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}