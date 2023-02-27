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
