using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Dto.Volunteer;

namespace Presentation.Controllers
{
    [Route("api/volunteers")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IServiceManager _service;

        public VolunteerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetVolunteers()
        {
            var volunteers = _service.VolunteerService.GetVolunteers(trackChanges: false);

            return Ok(volunteers);
        }

        [HttpGet("{id:guid}", Name = "VolunteerById")]
        public IActionResult GetVolunteer(Guid id)
        {
            var volunter = _service.VolunteerService.GetVolunteer(id, trackChanges: false);

            return Ok(volunter);
        }
    
        [HttpPost]
        public IActionResult CreateVolunteer([FromBody] VolunteerForCreationDto volunteer)
        {
            if(volunteer is null)
                return BadRequest("The volunteer object is null");
            
            var volunterDto = _service.VolunteerService.CreateVolunteer(volunteer);

            return CreatedAtRoute("VolunteerById", new {id = volunterDto.Id}, volunterDto);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteVolunteer(Guid id)
        {
            _service.VolunteerService.DeleteVolunteer(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateVolunteer(Guid id, [FromBody] VolunteerForUpdateDto volunteer)
        {
            _service.VolunteerService.UpdateVolunteer(id, volunteer, trackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public IActionResult PartiallyUpdateVolunteer(Guid id, JsonPatchDocument<VolunteerForUpdateDto> patchDoc)
        {
            if(patchDoc is null)
                return BadRequest("The patchDoc object send from client is null");
            
            var result = _service.VolunteerService.GetVolunteerForPatch(id, trackChanges:true);

            patchDoc.ApplyTo(result.volunteerToPatch);

            _service.VolunteerService.SaveChangesForPatch(result.volunteerToPatch, result.volunteerEntity);

            return NoContent();
        }
    }

}