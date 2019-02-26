using IncidentManagement.Application.Models;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface ILocationService
    {
        LocationModel Get(int locationId, out string error);
        List<LocationModel> GetAll(out string error);
        int Create(string description, string name, out string error);
    }
}
