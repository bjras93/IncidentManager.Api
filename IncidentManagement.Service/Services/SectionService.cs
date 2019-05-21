using IncidentManagement.Application.Interfaces;
using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;
using System.Collections.Generic;

namespace IncidentManagement.Application.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        public Section Create(Section section)
        {
            _sectionRepository.Add(section);            
            _sectionRepository.SaveChanges();
            return section;
        }
        public Section Update(Section section)
        {
            _sectionRepository.Update(section);
            _sectionRepository.SaveChanges();
            return section;
        }
        public Section Get(int id)
        {
            return _sectionRepository.FindBy(x => x.Id == id).Result;
        }
        public List<Section> GetAll()
        {
            return _sectionRepository.GetAll().Result;
        }
    }
}
