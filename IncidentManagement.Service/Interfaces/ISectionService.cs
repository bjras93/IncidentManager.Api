using IncidentManagement.Domain;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface ISectionService
    {
        Section Get(int id);
        Section Create(Section section);
        Section Update(Section section);
        List<Section> GetAll();
    }
}
