using TestAec.Models.Weather;

namespace TestAec.Services.Interfaces;
public interface IWeatherService
{
    Task<WeatherCityResponse> GetByCityNameAsync(string cityName);
    Task<WeatherAirportResponse> GetBAirportCodeAsync(string airportCode);
}
