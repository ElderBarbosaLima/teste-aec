using SDKBrasilAPI.Responses;
using TestAec.Models.Weather;

namespace TestAec.Mappers.Interfaces;
public interface IMapper
{
    WeatherCityResponse Map(CptecPrevisaoResponse cptecPrevisaoResponse);
    WeatherAirportResponse Map(CptecClima cptecClimaResponse);
}

