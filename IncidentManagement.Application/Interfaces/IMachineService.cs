using IncidentManagement.Application.Models;
using IncidentManagement.Repository.DTO;
using System.Collections.Generic;

namespace IncidentManagement.Application.Interfaces
{
    public interface IMachineService
    {
        MachineModel Get(int machineId, out string error);
        int Create(string name, int locationId, out string error);
        List<MachineModel> GetAll(out string error);
    }
}
