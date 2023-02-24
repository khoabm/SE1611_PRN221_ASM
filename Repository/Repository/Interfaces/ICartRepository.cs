using Repository.Infrastructure;
using Repository.Entities;

namespace Repository.Repository.Interfaces
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        IEnumerable<Cart> GetAllCartsWithDetails();
        Cart? GetByIdWithDetails(int id);
    }
}
