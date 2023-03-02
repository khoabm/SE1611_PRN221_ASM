using Repository.Entities;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IGenreRepository: IRepositoryBase<Genre>
    {
        IEnumerable<Genre> GetGenresOrderByNumberOfBooks();
    }
}
