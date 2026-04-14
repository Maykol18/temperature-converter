using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : ControllerBase
    {
        public ConverterController()
        {
            
        }

        [HttpGet]
        public int ToCelcius(
            [Required][FromQuery] ETemperatureUnit from,
            [Required][FromQuery] ETemperatureUnit to,
            [Required][FromQuery] double value)
        {
            return (from, to) switch
            {
                (ETemperatureUnit.Celsius, ETemperatureUnit.Fahrenheit) => Converter.ToFahrenheit(ETemperatureUnit.Celsius, value),
                (ETemperatureUnit.Kelvin, ETemperatureUnit.Fahrenheit) => Converter.ToFahrenheit(ETemperatureUnit.Kelvin, value),
                (ETemperatureUnit.Fahrenheit, ETemperatureUnit.Celsius) => Converter.ToCelcius(ETemperatureUnit.Fahrenheit, value),
                (ETemperatureUnit.Kelvin, ETemperatureUnit.Celsius) => Converter.ToCelcius(ETemperatureUnit.Kelvin, value),
                (ETemperatureUnit.Fahrenheit, ETemperatureUnit.Kelvin) => Converter.ToKelvin(ETemperatureUnit.Fahrenheit, value),
                (ETemperatureUnit.Celsius, ETemperatureUnit.Kelvin) => Converter.ToKelvin(ETemperatureUnit.Celsius, value),
                _ => (int) value
            };
        }
    }
}