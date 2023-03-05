using Repository.Entities;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public class BookGenreRepository : RepositoryBase<BookGenre>, IBookGenreRepository
    {
        private readonly BookSellingContext _context;
        public BookGenreRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }
    }
}
