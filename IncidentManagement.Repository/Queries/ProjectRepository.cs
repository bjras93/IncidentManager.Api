using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ProjectRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
