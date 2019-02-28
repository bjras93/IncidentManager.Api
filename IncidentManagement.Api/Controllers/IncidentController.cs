using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private IIncidentService _incidentService;
        private readonly IMapper _mapper;
        public IncidentController(IIncidentService incidentService, IMapper mapper)
        {
            _incidentService = incidentService;
            _mapper = mapper;
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
        public IActionResult Create([FromBody]JObject data)
        {
            var incident = _incidentService.Create(int.Parse(data["createdBy"].ToString()), int.Parse(data["assignedTo"].ToString()), data["header"].ToString(), data["description"].ToString(), int.Parse(data["machineId"].ToString()), out string error);
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
        [HttpPost]
        public IActionResult Comment([FromBody]JObject data)
        {
            var comment = _incidentService.Comment(int.Parse(data["createdBy"].ToString()), int.Parse(data["incidentId"].ToString()), data["text"].ToString(), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(comment);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
    }
}