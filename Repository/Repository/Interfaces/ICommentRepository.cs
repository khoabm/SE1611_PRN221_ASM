using Repository.Infrastructure;
using Repository.Entities;

namespace Repository.Repository.Interfaces
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        (IEnumerable<Comment>, int totalItems) GetAllCommentOfABook(int bookId, int page);
        IEnumerable<Comment> GetAllCommentOfABookNoPaging(int bookId);
        void InsertComment(Comment comment);
    }
}
