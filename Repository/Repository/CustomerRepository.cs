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

    internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly BookSellingContext _context;

        public CustomerRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }
    }
}
