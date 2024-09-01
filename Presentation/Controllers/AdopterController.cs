using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/adopters")]
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

    }
}