using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        private readonly BookSellingContext _context;
        public CommentRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }
    }
}
