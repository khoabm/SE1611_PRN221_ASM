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
    public class OrderDetailRepository: RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        private readonly BookSellingContext _context;
        public OrderDetailRepository(BookSellingContext context): base(context)
        {
            _context = context;
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
