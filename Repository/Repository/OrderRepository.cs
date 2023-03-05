using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly BookSellingContext _context;
        public OrderRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == customerId)
                .ToList();
        }
        
    }
}