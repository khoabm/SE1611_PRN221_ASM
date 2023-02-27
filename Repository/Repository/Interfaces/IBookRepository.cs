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
        (List<Book>, int totalItems) SearchBooks(string query, string[] genres, double minPrice, double maxPrice);
        IEnumerable<Book> GetBooksOrderByAverageRating();
    }
}
