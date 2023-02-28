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
    }
}
