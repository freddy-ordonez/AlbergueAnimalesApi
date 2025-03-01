using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using Shared.Dto.Adopter;
using Shared.RequestFeactures;

namespace Presentation.Controllers
{
    [Route("api/adopters")]
    // [ApiController]
    public class AdopterController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdopterController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdopters([FromQuery] AdopterParameters adopterParameters)
        {
            var (adopterDtos, metaData) = await _service.AdopterService.GetAdoptersAsync(adopterParameters, trackChanges: false);

            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(metaData);

            return Ok(adopterDtos);
        }

        [HttpGet("{id:guid}", Name = "AdopterById")]
        public async Task<IActionResult> GetAdopter(Guid id)
        {
            var adopter = await _service.AdopterService.GetAdopterAsync(id, trackChanges: false);

            return Ok(adopter);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAdopter([FromBody] AdopterForCreationDto adopter)
        {   
            var adopterDto = await _service.AdopterService.CreateAdopterAsync(adopter);

            return CreatedAtRoute("AdopterById", new {id = adopterDto.Id}, adopterDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAdopter(Guid id)
        {
            await _service.AdopterService.DeleteAdopterAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAdopter(Guid id, [FromBody] AdopterForUpdateDto adopter)
        {
            await _service.AdopterService.UpdateAdopterAsync(id, adopter, trackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateAdopter(Guid id, [FromBody] JsonPatchDocument<AdopterForUpdateDto> patchDoc)
        {
            if(patchDoc is null)
                return BadRequest("patchDoc object send from client is null");
            
            var (adopterToPatch, adopterEntity) = await _service.AdopterService.GetAdopterForPatchAsync(id, trackChanges: true);

            patchDoc.ApplyTo(adopterToPatch, ModelState);

            TryValidateModel(adopterToPatch);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.AdopterService.SaveChangesForPatchAsync(adopterToPatch, adopterEntity);

            return NoContent();
        }
    
    }
}