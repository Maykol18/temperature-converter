namespace API;

public static class Converter
{
    public static int ToCelcius(ETemperatureUnit @from, double value) => @from switch
    {
        ETemperatureUnit.Fahrenheit => ((value - 32) * 5/9 - Math.Floor((value - 32) * 5/9) > 0.5) ? (int)Math.Ceiling((value - 32) * 5/9) : (int)Math.Floor((value - 32) * 5/9),
        ETemperatureUnit.Kelvin => (value - 273.15 - Math.Floor(value - 273.15) > 0.5) ? (int)Math.Ceiling(value - 273.15) : (int)Math.Floor(value - 273.15),
        _ => (int)value
    };

    public static int ToFahrenheit(ETemperatureUnit @from, double value) => @from switch
    {
        ETemperatureUnit.Celsius => ((value * 9/5 + 32) - Math.Floor((value * 9/5 + 32)) > 0.5) ? (int)Math.Ceiling((value * 9/5 + 32)) : (int)Math.Floor((value * 9/5 + 32)),
        ETemperatureUnit.Kelvin => (value - 273.15) * 9/5 + 32 - Math.Floor((value - 273.15) * 9/5 + 32) > 0.5 ? (int)Math.Ceiling((value - 273.15) * 9/5 + 32) : (int)Math.Floor((value - 273.15) * 9/5 + 32),
        _ => (int)value
    };

    public static int ToKelvin(ETemperatureUnit @from, double value) => @from switch
    {
        ETemperatureUnit.Celsius => (value + 273.15 - Math.Floor(value + 273.15) > 0.5) ? (int)Math.Ceiling(value + 273.15) : (int)Math.Floor(value + 273.15),
        ETemperatureUnit.Fahrenheit => ((value - 32) * 5/9 + 273.15 - Math.Floor((value - 32) * 5/9 + 273.15) > 0.5) ? (int)Math.Ceiling((value - 32) * 5/9 + 273.15) : (int)Math.Floor((value - 32) * 5/9 + 273.15),
        _ => (int)value
    };
}

public enum ETemperatureUnit
{
    Fahrenheit,
    Kelvin,
    Celsius
}