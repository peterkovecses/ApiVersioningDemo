using V1 = ApiVersioningDemo.Models.V1;
using V2 = ApiVersioningDemo.Models.V2;

namespace ApiVersioningDemo.Controllers;

[ApiVersion(1)]
[ApiVersion(2)]
[ApiController]
[Route("api/v{v:apiVersion}/weather-forecasts")]
public class WeatherForecastController : ControllerBase
{
    
    [MapToApiVersion(1)]
    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<V1.WeatherForecast[]> GetV1()
    {
        return Enumerable.Range(1, 5).Select(index => new V1.WeatherForecast()
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
    }
    
    [MapToApiVersion(2)]
    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<V2.WeatherForecast[]> GetV2()
    {
        return Enumerable.Range(1, 5).Select(index => new V2.WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Temperature = new V2.Temperature(Random.Shared.Next(-20, 55))
            })
            .ToArray();
    }
    
    [MapToApiVersion(1)]
    [MapToApiVersion(2)]
    [HttpGet("average{days:int}", Name = "GetAverageTemperature")]
    public ActionResult<V1.AverageTemperature> GetAverageTemperature(int days = 5)
    {
        if (days < 1) return BadRequest("Days must be at least 1.");

        var today = DateOnly.FromDateTime(DateTime.Now);
        var endDate = today.AddDays(days - 1);
        var avgTempC = Enumerable.Range(1, days)
            .Select(i => Random.Shared.Next(-20, 55))
            .Average();

        return new V1.AverageTemperature
        {
            StartDate = today,
            EndDate = endDate,
            AverageTemperatureC = Math.Round(avgTempC, 1)
        };
    }
}