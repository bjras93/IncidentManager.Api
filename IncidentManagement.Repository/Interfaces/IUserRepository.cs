using IncidentManagement.Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<List<User>> AllByType(int userType);
    }
}
