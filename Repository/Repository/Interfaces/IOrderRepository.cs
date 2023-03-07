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
        IEnumerable<Order> GetOrderByCustomerId(int  customerId);
        public int GetBooksSoldThisMonth();
        public double GetTotalEarnings();
        public int GetTotalBookSold();
    }
}
