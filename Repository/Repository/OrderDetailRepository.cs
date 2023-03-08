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
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        private readonly BookSellingContext _context;
        public OrderDetailRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail>? GetCustomerOrderDetailByOrderId(int accountId, int orderId)
        {
            return _context.Customers
                                    .Include(c => c.Orders)
                                    .ThenInclude(o => o.OrderDetails)
                                    .Where(c => c.CustomerId == accountId)
                                    .SelectMany(c => c.Orders)
                                    .Where(o => o.OrderId == orderId)
                                    .SelectMany(o => o.OrderDetails)
                                    .ToList();
        }

        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Include(od => od.Book)
                .ToList();
        }

    }
}
