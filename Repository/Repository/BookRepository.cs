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

        public List<Genre> GetBookGenres(int id)
        {
            return _context.Genres.Where(g => g.BookGenres.Any(bg => bg.BookId == id)).ToList();
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

        public (List<Book>, int totalItems) SearchBooks(string query, string[] genres, double minPrice, double maxPrice
                                                        , int pageNum, int pageSize)
        {
            List<Book> books = _context.Books.ToList();
            List<Book> list = new List<Book>();
            //-----------------------------------
            Console.WriteLine(query);
            //search by query title and author
            if (!string.IsNullOrEmpty(query))
            {
                books = books.Where(b => (b.Title.Contains(query) || b.Author.Contains(query))).ToList();
            }
            //filter by price
            books = books.Where(b => (b.Price <= maxPrice && b.Price >= minPrice)).ToList();
            //filter by genre
            if (genres.Length > 0)
            {
                Console.WriteLine(genres);
                List<BookGenre> bookGenres = _context.BookGenres.Where(bg => genres.Contains(bg.Genre.GenreName)).ToList();
                books = books.Where(b => bookGenres.Any(bg => bg.BookId == b.BookId)).ToList();
            }
            //----------------------------
            int totalItems = books.Count();
            return (PaginatedList<Book>.Create(books.AsQueryable(),pageNum,pageSize), totalItems);
        }
    }
}
