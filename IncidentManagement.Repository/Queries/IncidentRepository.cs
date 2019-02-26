using System.Linq;
using System.Threading.Tasks;
using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.Repository.Queries
{
    public class IncidentRepository : BaseRepository<Incident>, IIncidentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public IncidentRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;            
        }
        /// <summary>
        /// Includes:
        /// CreatedBy: user
        /// AssignedTo: user
        /// Comments
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Incident</returns>
        public Task<Incident> Includes(int id)
        {
            return Task.FromResult(_repositoryContext.Incidents.Include(u => u.CreatedBy).Include(u => u.AssignedTo).Include(i => i.Comments).Include(i => i.Comments).ThenInclude(c => c.User).FirstOrDefault(i => i.Id == id));
        }
    }
}
