using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public LocationRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
