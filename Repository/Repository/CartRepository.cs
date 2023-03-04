using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        private readonly BookSellingContext _context;
        public CartRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public Cart? GetByBookIdAndCustomerId(int bookId, int customerId)
        {
            return _context.Carts
                .SingleOrDefault(c => c.BookId == bookId && c.CustomerId == customerId);
        }

        public IEnumerable<Cart> GetCartByCustomerId(int customerId)
        {
            return _context.Carts
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Book)
                .ToList();
        }
    }
}
