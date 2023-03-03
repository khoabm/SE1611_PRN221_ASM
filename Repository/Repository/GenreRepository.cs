using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        private readonly BookSellingContext _context;
        public GenreRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenresOrderByNumberOfBooks()
        {
            var genres = new List<Genre>();
            try
            {
                genres = _context.Genres
                                            .Join(
                                                _context.BookGenres,
                                                genre => genre.GenreId,
                                                bookGenre => bookGenre.GenreId,
                                                (genre, bookGenre) => new { Genre = genre, BookGenre = bookGenre }
                                            )
                                            .GroupBy(
                                                x => new { x.Genre.GenreId, x.Genre.GenreName },
                                                (key, group) => new
                                                {
                                                    GenreId = key.GenreId,
                                                    GenreName = key.GenreName,
                                                    BookCount = group.Count()
                                                }
                                            )
                                            .OrderByDescending(x => x.BookCount).Select(c => new Genre
                                            {
                                                GenreId = c.GenreId,
                                                GenreName = c.GenreName
                                            }).Take(5).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return genres;
        }
    }
}
