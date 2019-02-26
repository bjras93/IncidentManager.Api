using IncidentManagement.Repository.DTO;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.Interfaces
{
    public interface IIncidentRepository: IBaseRepository<Incident>
    {
        Task<Incident> Includes(int id);
    }
}
