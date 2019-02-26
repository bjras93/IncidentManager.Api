using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class IncidentRepository : BaseRepository<Incident>, IIncidentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public IncidentRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
