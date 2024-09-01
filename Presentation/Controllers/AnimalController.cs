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
            var animals = _service.AnimalService.GetAllAnimals(trackChanges: false);
            return Ok(animals);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAnimal(Guid id)
        {
            var client = _service.AnimalService.GetAnimal(id, trackChanges: false);
            return Ok(client);
        }
    }
}