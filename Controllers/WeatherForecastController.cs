
using Microsoft.AspNetCore.Mvc;

namespace servicetwo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger<WeatherForecastController> _logger;
    private AppDbContext _ctx;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    [HttpPost("post")]
    public async Task<IActionResult> Post(WeatherForecast weather)
    {
        if (ModelState.IsValid)
        {
            _ctx.Add(weather);
            await _ctx.SaveChangesAsync();
        }
        return Ok();
    }

    [HttpGet()]
    public IEnumerable<WeatherForecast> Get()
    {
        return _ctx.Weather.ToList();
    }
}
