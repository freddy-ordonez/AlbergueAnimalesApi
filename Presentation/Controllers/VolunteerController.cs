using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using Shared.Dto.Volunteer;

namespace Presentation.Controllers
{
    [Route("api/volunteers")]
    // [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public VolunteerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetVolunteers()
        {
            var volunteers = await _service.VolunteerService.GetVolunteersAsync(trackChanges: false);

            return Ok(volunteers);
        }

        [HttpGet("{id:guid}", Name = "VolunteerById")]
        public async Task<IActionResult> GetVolunteer(Guid id)
        {
            var volunter = await _service.VolunteerService.GetVolunteerAsync(id, trackChanges: false);

            return Ok(volunter);
        }
    
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateVolunteer([FromBody] VolunteerForCreationDto volunteer)
        {
            if(volunteer is null)
                return BadRequest("The volunteer object is null");
            
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            
            var volunterDto = await _service.VolunteerService.CreateVolunteerAsync(volunteer);

            return CreatedAtRoute("VolunteerById", new {id = volunterDto.Id}, volunterDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVolunteer(Guid id)
        {
            await _service.VolunteerService.DeleteVolunteerAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateVolunteer(Guid id, [FromBody] VolunteerForUpdateDto volunteer)
        {
            if(volunteer is null)
                return BadRequest("The object send from the client is null");
            
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.VolunteerService.UpdateVolunteerAsync(id, volunteer, trackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateVolunteer(Guid id, [FromBody] JsonPatchDocument<VolunteerForUpdateDto> patchDoc)
        {
            if(patchDoc is null)
                return BadRequest("The patchDoc object send from client is null");
            
            var (volunteerToPatch, volunteerEntity) = await _service.VolunteerService.GetVolunteerForPatchAsync(id, trackChanges:true);

            patchDoc.ApplyTo(volunteerToPatch, ModelState);

            TryValidateModel(volunteerToPatch);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.VolunteerService.SaveChangesForPatchAsync(volunteerToPatch, volunteerEntity);

            return NoContent();
        }
    }

}