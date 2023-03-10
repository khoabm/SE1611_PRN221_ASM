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

        public Order? GetByOrderId(int id)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Book)
                .FirstOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == customerId)
                .ToList();
        }
        public int GetBooksSoldThisMonth()
        {
            return _context.Orders
                .Where(o => o.PlaceDate!.Value.Month == DateTime.Today.Month && o.PlaceDate!.Value.Year == DateTime.Today.Year && o.Status == 3)
                .SelectMany(o => o.OrderDetails)
                .Sum(od => od.Quantity) ?? 0;
        }

        public double GetTotalEarnings()
        {
            return _context.Orders
                .Where(o => o.Status == 3)
                .Sum(o => o.TotalAmount) ?? 0;
        }

        public int GetTotalBookSold()
        {
            return _context.Orders
                .Where(o => o.Status == 3)
                .SelectMany(o => o.OrderDetails)
                .Sum(od => od.Quantity) ?? 0;
        }

        public (List<Order>, int totalItems) SearchOrders(string query, double minPrice, double maxPrice, int pageNum, int pageSize, string sort)
        {
            List<Order> orders = _context.Orders.Include(o => o.Customer).Where(o => o.Customer.Name.Contains(query)).ToList();
            //search
            
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

        public void ChangeOrderStatus(int id, int status)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            order.Status = Convert.ToInt16(status);
            _context.SaveChanges();
        }
    }
}