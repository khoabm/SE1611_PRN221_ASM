using Repository.Infrastructure;
using Repository.Entities;

namespace Repository.Repository.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        (IEnumerable<Comment>, int totalItems) GetAllCommentOfABook(int bookId, int page);
        void InsertComment(Comment comment);
    }
}
