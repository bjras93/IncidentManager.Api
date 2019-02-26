using IncidentManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private IMachineService _machineService;
        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }
        [HttpPost]
        public IActionResult Get(int incidentId)
        {
            var machine = _machineService.Get(incidentId, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(machine);
            }
            else
            {
                return StatusCode(500, error);
            }

        }
        [HttpPost]
        public IActionResult Create([FromBody]JObject data)
        {
            var machine = _machineService.Create(data["name"].ToString(), int.Parse(data["locationId"].ToString()), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(machine);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var machines = _machineService.GetAll(out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(machines);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
    }
}