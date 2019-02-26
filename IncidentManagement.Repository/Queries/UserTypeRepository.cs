using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class UserTypeRepository : BaseRepository<UserType>, IUserTypeRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public UserTypeRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
