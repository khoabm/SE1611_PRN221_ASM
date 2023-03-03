using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        private const int Comment_PAGE_SIZE = 3;
        private readonly BookSellingContext _context;
        public CommentRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public  (IEnumerable<Comment>, int totalItems) GetAllCommentOfABook(int bookId, int page)
        {
            var commentsByBook = new List<Comment>();
            int totalItems = 0; 
            try
            {
                commentsByBook =  _context.Comments.Include(c => c.Customer).Where(c => c.BookId == bookId).OrderByDescending(c => c.CommentDate).ToList();
                totalItems = commentsByBook.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
            return (PaginatedList<Comment>.Create(commentsByBook.AsQueryable(), page, Comment_PAGE_SIZE), totalItems);
        }

        public void InsertComment(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}
