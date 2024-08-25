using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace AlbergueAnimalesRescatadosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInfo("Log Info");
            _logger.LogWarn("Log Warn");
            _logger.LogDebug("Log Debug");
            _logger.LogError("Log Error");
            return "Hola mundo";
        }
    }
}
