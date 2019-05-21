using IncidentManagement.Domain;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.Interfaces
{
    public interface IMachineRepository: IBaseRepository<Machine>
    {
        Task<Machine> WithIncidents(int id);
    }
}
