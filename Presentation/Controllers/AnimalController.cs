using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using Shared.Dto.Animal;
using Shared.RequestFeactures;

namespace Presentation.Controllers
{
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AnimalController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals([FromQuery] AnimalParameters animalParameters)
        {
            var animals = await _service.AnimalService.GetAllAnimalAsync(animalParameters, trackChanges: false);
            return Ok(animals);
        }

        [HttpGet("{id:guid}", Name = "AnimalById")]
        public async Task<IActionResult> GetAnimal(Guid id)
        {
            var client = await _service.AnimalService.GetAnimalAsync(id, trackChanges: false);
            return Ok(client);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAnimal([FromBody] AnimalForCreationDto animal)
        {  
            var animalCreate = await _service.AnimalService.CreateAnimalAsync(animal);

            return CreatedAtRoute("AnimalById", new {id = animalCreate.Id}, animalCreate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAnimal(Guid id)
        {
            await _service.AnimalService.DeleteAnimalAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAnimal(Guid id, [FromBody] AnimalForUpdateDto animal)
        {
            await _service.AnimalService.UpdateAnimalAsync(id, animal, trackChanges: true);

            return NoContent();
        }
    
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateAnimal(Guid id, [FromBody] JsonPatchDocument<AnimalForUpdateDto> patchDoc)
        {
            if(patchDoc is null)
                return BadRequest("patchDoc object sent from client is null");
            
            var (animalToPatch, animalEntity ) = await _service.AnimalService.GetAnimalForPatchAsync(id, trackChanges: true);

            patchDoc.ApplyTo(animalToPatch, ModelState);

            TryValidateModel(animalToPatch);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.AnimalService.SaveChangesForPatchAsync(animalToPatch, animalEntity);
            
            return NoContent();
        }
    }
}