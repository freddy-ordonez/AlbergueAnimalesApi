using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AnimalController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            try
            {
                var animals = _service.AnimalService.GetAllAnimals(trackChanges: false);
                return Ok(animals);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}