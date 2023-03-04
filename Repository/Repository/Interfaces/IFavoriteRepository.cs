using Repository.Infrastructure;
using Repository.Entities;

namespace Repository.Repository.Interfaces
{
    public interface IFavoriteRepository : IRepositoryBase<Favorite>
    {
        IEnumerable<Favorite> GetFavoriteByCustomerId(int customerId);
        Favorite? GetByBookIdAndCustomerId(int bookId, int customerId);
    }
}
