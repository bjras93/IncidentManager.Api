using IncidentManagement.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.Interfaces
{
    public interface IMachineRepository: IBaseRepository<Machine>
    {
        Task<Machine> WithIncidents(int id);
    }
}
