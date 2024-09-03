using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Dto.Adopter;

namespace Presentation.Controllers
{
    [Route("api/adopters")]
    [ApiController]
    public class AdopterController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AdopterController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAdopters()
        {
            var adopters = _service.AdopterService.GetAdopters(trackChanges: false);

            return Ok(adopters);
        }

        [HttpGet("{id:guid}", Name = "AdopterById")]
        public IActionResult GetAdopter(Guid id)
        {
            var adopter = _service.AdopterService.GetAdopter(id, trackChanges: false);

            return Ok(adopter);
        }

        [HttpPost]
        public IActionResult CreateAdopter([FromBody] AdopterForCreationDto adopter)
        {
            if(adopter is null)
                return BadRequest("The adopter object is null");
            
            var adopterDto = _service.AdopterService.CreateAdopter(adopter);

            return CreatedAtRoute("AdopterById", new {id = adopterDto.Id}, adopterDto);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAdopter(Guid id)
        {
            _service.AdopterService.DeleteAdopter(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateAdopter(Guid id, [FromBody] AdopterForUpdateDto adopter)
        {
            _service.AdopterService.UpdateAdopter(id, adopter, trackChanges: true);

            return NoContent();
        }
    }
}