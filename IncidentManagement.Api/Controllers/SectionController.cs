using System.Collections.Generic;
using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        [HttpGet]
        public Section Get(int id)
        {
            return _sectionService.Get(id);
        }
        [HttpPost]
        public Section Create(Section section)
        {
            return _sectionService.Create(section);
        }
        [HttpPost]
        public Section Update(Section section)
        {
            return _sectionService.Update(section);
        }
        [HttpGet]
        public List<Section> GetAll()
        {
            return _sectionService.GetAll();
        }
    }
}