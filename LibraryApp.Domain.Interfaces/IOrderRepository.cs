using LibraryApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    internal interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        void Create(Order order);
        void Update(Order order);
    }
}
