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


        public IEnumerable<Book> GetBooksOrderByAddedDate()
        {
            var books = new List<Book>();
            try
            {
                books = _context.Books.OrderByDescending(b => b.AddedDate).ToList();
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return books;
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


        public IEnumerable<Book> GetBooksOrderByCategory(string categoryName)
        {
            var books = new List<Book>();
            try
            {

                //String query = $" SELECT top 4 db.publisher, db.image_link, db.price, db.quantity_left, db.[status], db.title, db.[description] ,db.author,db.AddedDate, db.book_id, db.average, genre_name FROM ( SELECT b.publisher, b.image_link, b.price, b.quantity_left, b.[status], b.title, b.[description] ,b.author, b.AddedDate, b.book_id, AVG(cm.rating) as average FROM Books b join Comments cm on b.book_id = cm.book_id GROUP BY b.book_id, b.AddedDate, b.author, b.[description], b.publisher, b.image_link, b.price, b.quantity_left, b.[status], b.title ) as db join Book_genre bg on db.book_id = bg.book_id join Genres g on bg.genre_id = g.genre_id WHERE g.genre_name LIKE '%{categoryName}%' ORDER BY db.average";
                //books = _context.Books.FromSqlRaw(query).ToList();
                books = (from b in _context.Books
                         join bg in _context.BookGenres on b.BookId equals bg.BookId
                         join g in _context.Genres on bg.GenreId equals g.GenreId
                         join cm in _context.Comments on b.BookId equals cm.BookId into cmGroup
                         where g.GenreName.Contains(categoryName)
                         let average = cmGroup.Average(cm => cm.Rating)
                         orderby average descending

                         //orderby cmAvg.Average(x => x.FirstOrDefault().Rating ?? 0) descending
                         select new Book
                         {
                             BookId = b.BookId,
                             Title = b.Title,
                             Author = b.Author,
                             Description = b.Description,
                             Publisher = b.Publisher,
                             Price = b.Price,
                             QuantityLeft = b.QuantityLeft,
                             Status = b.Status,
                             AddedDate = b.AddedDate,
                             ImageLink = b.ImageLink,
                             AverageRating = average ?? 0,
                             //BookGenres = cmAvg.Key.b.BookGenres
                         }).Take(4).ToList();
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return books;
        }


        public (List<Book>, int totalItems) SearchBooks(string query, string[] genres, double minPrice, double maxPrice
                                                        , int pageNum, int pageSize, string sort)

        {
            List<Book> books = _context.Books.Include(b => b.Comments).ToList();
            List<Book> list = new List<Book>();
            //-----------------------------------
            //search by query title and author
            if (!string.IsNullOrEmpty(query))
            {
                books = books.Where(b => b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)
                || b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
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
            foreach (var book in books)
            {
                if (book.Comments.Count > 0)
                {
                    double averageRating = book.Comments.Average(c => c.Rating!.Value);
                    book.AverageRating = averageRating;
                }
                else { book.AverageRating = 0; }
            }
            //----------------------------
            //sort
            if (sort.Equals("latest")) books = books.OrderBy(b => b.AddedDate).ToList();
            if (sort.Equals("oldest")) books = books.OrderByDescending(b => b.AddedDate).ToList();
            if (sort.Equals("price")) books = books.OrderBy(b => b.Price).ToList();
            ///
            int totalItems = books.Count();

            return (PaginatedList<Book>.Create(books.AsQueryable(), pageNum, pageSize), totalItems);
        }

        public IEnumerable<Book> GetBooksWithTheSameGenres(Book book)
        {
            var books = new List<Book>();
            try
            {
                var targetBook = _context.Books.Include(b => b.BookGenres).FirstOrDefault(b => b.BookId == book.BookId);

                var similarBooks = _context.Books
                                                .Where(b => b.BookId != targetBook.BookId && _context.BookGenres
                                                    .Any(bg => bg.BookId == b.BookId && _context.BookGenres
                                                        .Any(tbg => tbg.BookId == targetBook.BookId && tbg.GenreId == bg.GenreId)))
                                                .ToList();

                var similarBookList = similarBooks.Take(8).ToList();
                Console.WriteLine(similarBookList.Count);
                books = similarBookList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }

            return books;

        }
    }
}
