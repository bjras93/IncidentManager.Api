using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;

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
        public IActionResult Get([FromBody]JObject data)
        {
            var machine = _machineService.Get(Convert.ToInt32(data["id"]), out string error);
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
            var machine = _machineService.Create(data["name"].ToString(), data["location"].ToString(), out string error);
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
        [HttpPost]
        public IActionResult Update([FromBody]JObject data)
        {
            var machine = data["machine"].ToObject<Machine>();
            var updated = _machineService.Update(machine, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(updated);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
    }
}