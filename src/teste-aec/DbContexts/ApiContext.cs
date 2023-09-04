using Microsoft.EntityFrameworkCore;
using TestAec.Models.Errors;
using TestAec.Models.Weather;

namespace TestAec.DbContexts;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
    : base(options)
    {
        
    }
    public DbSet<WeatherAirportResponse> WeatherAirportResponse { get; set; }
    public DbSet<ErrorMessage> Error { get; set; }
    public DbSet<WeatherCityResponse> WeatherCityResponse { get; set; }

}

