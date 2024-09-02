using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }

}