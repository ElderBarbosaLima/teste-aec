using SDKBrasilAPI;
using TestAec.Mappers.Interfaces;
using TestAec.Models.Weather;
using TestAec.Repository.Interfaces;
using TestAec.Services.Interfaces;

namespace TestAec.Services.Implementations;
public class BrasilApiService : IWeatherService
{
    private readonly IBrasilAPI _brasilAPI;
    private readonly IMapper _mapper;
    private readonly IWeatherRepository _weatherRepository;
    private readonly ILogger<BrasilApiService> _logger;

    public BrasilApiService(IBrasilAPI brasilAPI, IMapper mapper, IWeatherRepository weatherRepository, ILogger<BrasilApiService> logger)
    {
        _brasilAPI = brasilAPI;
        _mapper = mapper;
        _weatherRepository = weatherRepository;
        _logger = logger;
    }

    public async Task<WeatherCityResponse> GetByCityNameAsync(string cityName)
    {
        try
        {
            var citiesResponse = await _brasilAPI.CptecCidade(cityName[..4]);// Para o funcionamento da api, a chamada da api passa apenas os 4 primeiros caracteres, visto que a api retorna um erro quando se passa o nome completo da cidade. Foi aberta uma issue no projeto da Brasil Pi: https://github.com/BrasilAPI/BrasilAPI/issues/514
            var city = citiesResponse.Cidades.FirstOrDefault(c => c.nome == cityName); 
            if (city == null)
            {
                throw new Exception($"Cidade não encontrada {cityName}");
            }

            var weatherBrasilApi = await _brasilAPI.CptecClimaPrevisao(city.id);
            var weatherResponse = _mapper.Map(weatherBrasilApi);
            await _weatherRepository.SaveAsync(weatherResponse);
            return weatherResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"Erro ao tentar buscar clima pelo nome");
            throw;
        }
    }

    public async Task<WeatherAirportResponse> GetBAirportCodeAsync(string airportCode)
    {
        try
        {
            var weatherBrasilApi = (await _brasilAPI.CptecClimaAeroporto(airportCode)).Climas.FirstOrDefault();
            var weatherResponse = _mapper.Map(weatherBrasilApi);
            await _weatherRepository.SaveAsync(weatherResponse);
            return weatherResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar buscar clima pelo aeroporto");
            throw;
        }
    }
}