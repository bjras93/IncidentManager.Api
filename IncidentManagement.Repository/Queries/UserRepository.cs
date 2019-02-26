using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public UserRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
