using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

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
    }
}