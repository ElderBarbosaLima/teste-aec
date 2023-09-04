using TestAec.DbContexts;
using TestAec.Models.Weather;
using TestAec.Repository.Interfaces;

namespace TestAec.Repository.Implementations;
public class WeatherRepository : IWeatherRepository
{
    private readonly ApiContext _context;
    public WeatherRepository(ApiContext context)
    {
        _context = context;
    }
    public async Task SaveAsync<T>(T entity) where T : class
    {
         _context.Add(entity);
        await _context.SaveChangesAsync();
    }
}
