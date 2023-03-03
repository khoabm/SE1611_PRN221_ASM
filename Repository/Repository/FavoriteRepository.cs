using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public class FavoriteRepository : RepositoryBase<Favorite>, IFavoriteRepository
    {
        private readonly BookSellingContext _context;
        public FavoriteRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public Favorite? GetByBookIdAndCustomerId(int bookId, int customerId)
        {
            return _context.Favorites
                .SingleOrDefault(c => c.BookId == bookId && c.CustomerId == customerId);
        }

        public IEnumerable<Favorite> GetFavoriteByCustomerId(int customerId)
        {
            return _context.Favorites
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Book)
                .ToList();
        }
    }
}
