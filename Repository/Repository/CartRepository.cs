using Repository.Entities;
using Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Cart> GetAllCartsWithDetails()
        {
            return _context.Carts
                .Include(c => c.Book)
                .Include(c => c.Customer)
                .ToList();
        }
        public Cart? GetByIdWithDetails(int id)
        {
            var result = _context.Carts
                .Include(c => c.Book)
                .Include(c => c.Customer)
                .FirstOrDefault(c => c.CartId == id);
            return result;
        }
    }
}
