using IncidentManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost]
        public IActionResult Get(int locationId)
        {
            var result = _locationService.Get(locationId, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpPost]
        public IActionResult Create(string description, string name)
        {
            var result = _locationService.Create(description, name, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, error);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _locationService.GetAll(out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
    }
}