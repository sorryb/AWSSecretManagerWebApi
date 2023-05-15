using Microsoft.AspNetCore.Mvc;
using TestSecretManagerWebApi.Services;

namespace TestSecretManagerWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly MyService _myService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, MyService myService)
    {
        _logger = logger;
        _myService = myService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var secrets = _myService.GetSecrets();
        _logger.LogInformation($"User {secrets.UserId} with password {secrets.Password} and Api key {secrets.ApiKey}");

        var weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = $"The weather is {Summaries[Random.Shared.Next(Summaries.Length)]} for user {secrets.UserId} with password {secrets.Password} and key {secrets.ApiKey}"
        })
        .ToArray();

        return weather;
    }
}
