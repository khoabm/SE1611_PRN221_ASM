using Microsoft.EntityFrameworkCore;
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
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly BookSellingContext _context;
        public BookRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooksOrderByAverageRating()
        {
            var books = new List<Book>();
            try
            {
                books = (
                           from b in _context.Books
                           join c in _context.Comments on b.BookId equals c.BookId into gj
                           let avgRating = gj.Average(c => (double?)c.Rating) ?? 0
                           select new Book
                           {
                               BookId = b.BookId,
                               Title = b.Title,
                               Author = b.Author,
                               Price = b.Price,
                               QuantityLeft = b.QuantityLeft,
                               ImageLink = b.ImageLink,
                               Publisher = b.Publisher,
                               Description = b.Description,
                               AverageRating = avgRating
                           }
                        ).OrderByDescending(b => b.AverageRating).Take(8).ToList();
                //books = _context.Books
                //    .Join(_context.Comments,
                //        b => b.BookId,
                //        cm => cm.BookId,
                //        (b, cm) => new { Book = b, Rating = cm.Rating })
                //    .GroupBy(x => x.Book)
                //    .Select(g => new Book
                //    {
                //        BookId = g.Key.BookId,
                //        Title = g.Key.Title,
                //        Author = g.Key.Author,
                //        Price = g.Key.Price,
                //        QuantityLeft = g.Key.QuantityLeft,
                //        ImageLink = g.Key.ImageLink,
                //        Publisher = g.Key.Publisher,
                //        Description = g.Key.Description,

                //        AverageRating = g.Average(x => x.Rating) ?? 0
                //    })
                //    .OrderByDescending(b => b.AverageRating)
                //    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
            return books;
        }

        public (List<Book>, int totalItems) SearchBooks(string query, string[] genres, double minPrice, double maxPrice)
        {
            Console.WriteLine(genres[0]);
            //List<Book> list = _context.Books.Include(b => b.BookGenres)
            //                                        .ThenInclude(bg => bg.Genre)
            //                                        .Where(b => (b.Title.Contains(query)
            //                                        || b.Author.Contains(query))
            //                                        && (b.Price <= maxPrice
            //                                        && b.Price >= minPrice)
            //                                        //&& b.BookGenres.Any(bg =>
            //                                        //genres.Contains(bg.Genre.GenreName)
            //                                        //)
            //                                        ).ToList();

            List<Book> list = _context.Books.Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .Where(b =>
                    (b.Title.Contains(query) || b.Author.Contains(query))
                    && (b.Price <= maxPrice && b.Price >= minPrice)
                        && b.BookGenres.Any(bg =>
                        genres.Contains(bg.Genre.GenreName.ToLower())
                            ))
                    .ToList();
            int totalItems = list.Count();
            return (list, totalItems);
        }
    }
}
