using Repository.Entities;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        public (List<Book>, int totalItems) SearchBooks(string query, string[] genres, double minPrice, double maxPrice
                                                        , int pageNum, int pageSize,string sort);
        IEnumerable<Book> GetBooksOrderByAverageRating();

        IEnumerable<Book> GetBooksOrderByAddedDate();
        IEnumerable<Book> GetBooksOrderByCategory(String categoryName);

        List<Genre> GetBookGenres(int id);
        IEnumerable<Book> GetBooksWithTheSameGenres(Book book);

    }
}
