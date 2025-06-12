namespace ApiVersioningDemo.Models.V2;

public readonly record struct Temperature(int Celsius)
{
    public int Fahrenheit => 32 + (int)(Celsius / 0.5556);
}