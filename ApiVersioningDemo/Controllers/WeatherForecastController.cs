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
}