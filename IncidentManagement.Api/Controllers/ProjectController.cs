using AutoMapper;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        private readonly IMapper _mapper;
        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Get([FromBody]JObject data)
        {
            var id = int.Parse(data["id"].ToString());
            var project = _projectService.Get(id, out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(project);
            }
            else
            {
                return StatusCode(500, error);
            }

        }
        [HttpPost]
        public IActionResult Create([FromBody]JObject data)
        {
            var project = _projectService.Create(int.Parse(data["createdBy"].ToString()), int.Parse(data["assignedTo"].ToString()), data["header"].ToString(), data["description"].ToString(), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(project);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectService.GetAll(out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(projects);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpPost]
        public IActionResult GetCreated([FromBody]JObject data)
        {
            var projects = _projectService.GetCreated(Convert.ToInt32(data["id"]), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(projects);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpPost]
        public IActionResult GetAssigned([FromBody]JObject data)
        {
            var projects = _projectService.GetAssigned(Convert.ToInt32(data["id"]), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(projects);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpPost]
        public IActionResult Comment([FromBody]JObject data)
        {
            var comment = _projectService.Comment(int.Parse(data["createdBy"].ToString()), int.Parse(data["projectId"].ToString()), data["text"].ToString(), out string error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(comment);
            }
            else
            {
                return StatusCode(500, error);
            }
        }
        [HttpPost]
        public IActionResult Update([FromBody]JObject data)
        {
            var project = data["project"].ToObject<Project>();
            var updated = _projectService.Update(project, out string error);
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