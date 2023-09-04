using TestAec.Models.Weather;

namespace TestAec.Repository.Interfaces;
public interface IWeatherRepository
{
    Task SaveAsync<T>(T entity) where T: class;
}

