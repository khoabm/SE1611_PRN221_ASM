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
using static System.Reflection.Metadata.BlobBuilder;

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

        public (List<Order>, int totalItems) SearchOrders(string query, double minPrice, double maxPrice, int pageNum, int pageSize, string sort)
        {
            List<Order> orders = _context.Orders.Include(o => o.Customer).ToList();
            //sort
            if (sort.Equals("latest")) orders = orders.OrderBy(b => b.PlaceDate).ToList();
            if (sort.Equals("oldest")) orders = orders.OrderByDescending(b => b.PlaceDate).ToList();

            int totalItems = orders.Count();
            return (PaginatedList<Order>.Create(orders.AsQueryable(), pageNum, pageSize), orders.Count());
        }

        public (List<Order>, int totalItems) SearchOrdersCustomer(string query, double minPrice, double maxPrice, int pageNum, int pageSize, string sort, int customerId)
        {
            List<Order> orders = _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == customerId)
                .ToList();
            if (sort.Equals("latest")) orders = orders.OrderBy(b => b.PlaceDate).ToList();
            if (sort.Equals("oldest")) orders = orders.OrderByDescending(b => b.PlaceDate).ToList();

            int totalItems = orders.Count();
            return (PaginatedList<Order>.Create(orders.AsQueryable(), pageNum, pageSize), orders.Count());
        }
    }
}