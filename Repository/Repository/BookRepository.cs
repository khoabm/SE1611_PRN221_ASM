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

    }
}
