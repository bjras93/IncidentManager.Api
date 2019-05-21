using IncidentManagement.Domain;
using IncidentManagement.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentManagement.Repository.Queries
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public UserRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
        public Task<List<User>> AllByType(int typeId)
        {
            return Task.FromResult(_repositoryContext.Users.Where(u => u.UserType.Id == typeId).ToList());
        }
    }
}
