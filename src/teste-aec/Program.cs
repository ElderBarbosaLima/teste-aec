using Microsoft.EntityFrameworkCore;
using SDKBrasilAPI;
using TestAec.Configuration;
using TestAec.DbContexts;
using TestAec.Mappers.Implamentations;
using TestAec.Mappers.Interfaces;
using TestAec.Repository.Implementations;
using TestAec.Repository.Interfaces;
using TestAec.Services.Implementations;
using TestAec.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBrasilApi();
builder.Services.AddScoped<IWeatherService, BrasilApiService>();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddScoped<ApiContext>();

var connectionString = builder.Configuration.GetConnectionString("apiContext");
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddDbContext<ApiContext>(options =>
         options.UseSqlServer(connectionString));
var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("startin application");
app.UseErrorHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c => c.AllowAnyOrigin());

//app./*UseHttpsRedirection*/();

app.UseAuthorization();

app.MapControllers();

app.Run();
