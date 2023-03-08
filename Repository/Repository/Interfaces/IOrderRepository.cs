using Repository.Entities;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IOrderRepository: IRepositoryBase<Order>
    {
        public (List<Order>, int totalItems) SearchOrders(string query, double minPrice, double maxPrice
                                                        , int pageNum, int pageSize, string sort);
        public (List<Order>, int totalItems) SearchOrdersCustomer(string query, double minPrice, double maxPrice
                                                        , int pageNum, int pageSize, string sort, int customerId);
        Order? GetByOrderId(int id);
        IEnumerable<Order> GetOrderByCustomerId(int  customerId);
        public int GetBooksSoldThisMonth();
        public double GetTotalEarnings();
        public int GetTotalBookSold();
    }
}
