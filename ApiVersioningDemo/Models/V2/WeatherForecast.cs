namespace ApiVersioningDemo.Models.V2;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public Temperature Temperature { get; init; }

    public string Summary =>
        Temperature.Celsius switch
        {
            < 0 => "Freezing",
            < 10 => "Cold",
            < 20 => "Mild",
            < 30 => "Warm",
            _ => "Hot"
        };
}