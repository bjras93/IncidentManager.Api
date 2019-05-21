using IncidentManagement.Domain;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface ILocationService
    {
        Location Get(int locationId, out string error);
        List<Location> GetAll(out string error);
        int Create(string description, string name, out string error);
    }
}
