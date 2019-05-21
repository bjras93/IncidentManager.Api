using IncidentManagement.Domain;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IMachineService
    {
        Machine Get(int machineId, out string error);
        int Create(string name, string locationName, out string error);
        List<Machine> GetAll(out string error);
        bool Update(Machine machine, out string error);
    }
}
