using Repository.Infrastructure;
using Repository.Entities;

namespace Repository.Repository.Interfaces
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        IEnumerable<Cart> GetCartByCustomerId(int customerId);
        Cart? GetByBookIdAndCustomerId(int bookId, int customerId);
    }
}
