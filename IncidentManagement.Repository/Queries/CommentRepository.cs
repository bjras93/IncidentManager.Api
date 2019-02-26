using IncidentManagement.Repository.DTO;
using IncidentManagement.Repository.Interfaces;

namespace IncidentManagement.Repository.Queries
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public CommentRepository(RepositoryContext context) : base(context)
        {
            _repositoryContext = context;
        }
    }
}
