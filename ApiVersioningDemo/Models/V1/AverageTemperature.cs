namespace ApiVersioningDemo.Models.V1;

public class AverageTemperature
{
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public double AverageTemperatureC { get; init; }
    public double AverageTemperatureF => Math.Round(AverageTemperatureC * 9 / 5 + 32, 1);
}