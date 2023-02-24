using Repository.Entities;
using Repository.Repository.Interfaces;
using Repository.Repository;

namespace Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookSellingContext _context;
        private ICartRepository _cartRepository;
        private ICommentRepository _commentRepository;
        private IFavoriteRepository _favoriteRepository;
        private IAccountRepository _accountRepository;

        public UnitOfWork(BookSellingContext context)
        {
            _context = context;
        }
        // Assign if null

        //public IRepositoryBase<Cart> Carts
        //{
        //    get
        //    {
        //        if (_cartRepository == null)
        //        {
        //            this._cartRepository = new RepositoryBase<Cart>(_context);
        //        }
        //        return _cartRepository;
        //    }
        //}
        public ICartRepository CartRepository => _cartRepository ??= new CartRepository(_context);
        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_context);
        public IFavoriteRepository FavoriteRepository => _favoriteRepository ??= new FavoriteRepository(_context);

        public IAccountRepository AccountRepository => _accountRepository ??= new AccountRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
