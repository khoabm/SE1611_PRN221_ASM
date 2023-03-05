using Repository.Entities;
using Repository.Repository.Interfaces;

namespace Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository CartRepository { get; }
        ICommentRepository CommentRepository { get; }
        IFavoriteRepository FavoriteRepository { get; }
        IAccountRepository AccountRepository { get; }
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        IBookGenreRepository BookGenreRepository { get; }
        void Save();
    }
}
