using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private IIncidentService _incidentService;
        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        [HttpPost]
        public IActionResult Get([FromBody]JObject data)
        {
            var id = int.Parse(data["id"].ToString());
            var incident = _incidentService.Get(id, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(incident);
            }
            else
            {
                return StatusCode(500, error);
            }
            
        }
        [HttpPost]
        public IActionResult Create(int createdBy, int assignedTo, string header, string description, int location)
        {
            var incident = _incidentService.Create(createdBy, assignedTo, header, description, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(incident);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var incidents = _incidentService.GetAll(out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(incidents);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
    }
}