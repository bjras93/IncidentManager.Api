using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public SectionRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
