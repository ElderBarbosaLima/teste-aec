using Microsoft.AspNetCore.Mvc;
using TestAec.Services.Interfaces;

namespace TestAec.Controllers;
[Route("weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    //private readonly IWeatherRepository _weatherRepository;
    private readonly ILogger<WeatherController> _logger;
    private const string ERROR_MESSAGE_EMPTY_PARAMETER = "O parâmetro deve ser preenchido";
    private const string ERROR_MESSAGE_LENGTH_WRONG = "O parâmetro deve ter {0} caracteres";
    public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
    {
        _weatherService = weatherService;
        //_weatherRepository = weatherRepository;
        _logger = logger;
    }

    [HttpGet("get-by-city-name/{cityName}")]
    public async Task<IActionResult> GetByCityNameAsync( string cityName)
    {
        _logger.LogTrace("request {MethodName} - cityName: {CityName}", nameof(GetByCityNameAsync), cityName);
        if (string.IsNullOrEmpty(cityName))
        {
            return BadRequest(ERROR_MESSAGE_EMPTY_PARAMETER);
        }
        var weather = await _weatherService.GetByCityNameAsync(cityName);
        _logger.LogTrace("response {Weather}", weather);
        return Ok(weather);
    }
    [HttpGet("get-by-airport-code/{ariportCode}")]
    public async Task<IActionResult> GetByAirportAsync(string ariportCode)
    {
        _logger.LogTrace("request {MethodName} - cityName: {CityName}", nameof(GetByAirportAsync), ariportCode);
        if (string.IsNullOrEmpty(ariportCode))
        {
            return BadRequest(ERROR_MESSAGE_EMPTY_PARAMETER);
        }
        if (ariportCode.Length != 4)
        {
            return BadRequest(error: string.Format(ERROR_MESSAGE_EMPTY_PARAMETER, 4));
        }
        var weather = await _weatherService.GetBAirportCodeAsync(ariportCode);
        _logger.LogTrace("response {Weather}", weather);
        return Ok(weather);
    }
}