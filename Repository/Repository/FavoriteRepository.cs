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
    }
}
