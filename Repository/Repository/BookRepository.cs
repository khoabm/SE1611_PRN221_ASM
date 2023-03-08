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

                books = (from b in _context.Books
                         join bg in _context.BookGenres on b.BookId equals bg.BookId
                         join g in _context.Genres on bg.GenreId equals g.GenreId
                         join cm in _context.Comments on b.BookId equals cm.BookId into cmGroup
                         where g.GenreName.Equals(categoryName)
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

            List<Book> books = _context.Books.Include(b => b.Comments).Where(b => b.Status == 1).ToList();

            //-----------------------------------
            //search by query title and author
            if (!string.IsNullOrEmpty(query))
            {
                books = books.Where(b => b.Author!.Contains(query, StringComparison.OrdinalIgnoreCase)
                || b.Title!.Contains(query, StringComparison.OrdinalIgnoreCase) 
                || b.Publisher!.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
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
            if (sort.Equals("rating")) books = books.OrderByDescending(b => b.AverageRating).ToList();
            ///
            int totalItems = books.Count();

            return (PaginatedList<Book>.Create(books.AsQueryable(), pageNum, pageSize), totalItems);
        }
        public int CreateBookGenre(int bookId, int genreId)
        {
            try
            {
                BookGenre bg = new BookGenre();
                bg.GenreId = genreId;
                bg.BookId = bookId;
                _context.BookGenres.Add(bg);
                return genreId;
            }
            catch(Exception e)
            {
                return -1;
            }
                
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
                                                .Include(b => b.Comments)
                                                .ToList();

                var similarBookList = similarBooks.Take(8).ToList();
                
                Console.WriteLine(similarBookList.Count);
                foreach (var similarBook in similarBookList)
                {
                    if (similarBook.Comments.Count > 0)
                    {
                        double averageRating = similarBook.Comments.Average(c => c.Rating!.Value);
                        similarBook.AverageRating = averageRating;
                    }
                    else { similarBook.AverageRating = 0; }
                }
                
                books = similarBookList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }

            return books;

        }




        public (List<Book>, int totalItems) SearchBooksAdmin(string query, string[] genres, double minPrice, double maxPrice
                                                , int pageNum, int pageSize, string sort)

        {

            List<Book> books = _context.Books.Include(b => b.Comments).ToList();


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

    }
}
