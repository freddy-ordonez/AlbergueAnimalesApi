using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Dto;
using Shared.Dto.Animal;

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

        [HttpGet("{id:guid}", Name = "AnimalById")]
        public IActionResult GetAnimal(Guid id)
        {
            var client = _service.AnimalService.GetAnimal(id, trackChanges: false);
            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] AnimalForCreationDto animal)
        {
            if(animal is null)
                return BadRequest("The AnimalDto object is null ");
            
            var animalCreate = _service.AnimalService.CreateAnimal(animal);

            return CreatedAtRoute("AnimalById", new {id = animalCreate.Id}, animalCreate);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAnimal(Guid id)
        {
            _service.AnimalService.DeleteAnimal(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateAnimal(Guid id, [FromBody] AnimalForUpdateDto animal)
        {
            _service.AnimalService.UpdateAnimal(id, animal, trackChanges: true);

            return NoContent();
        }
    }
}