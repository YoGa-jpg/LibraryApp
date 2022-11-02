using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Infrastructure.Data.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private DataContext dataContext;

        public OrderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(Order order)
        {
            dataContext.Orders.Add(order);
        }
        public void Delete(int id)
        {
            Order order = dataContext.Orders.Find(id);
            if(order != null)
                dataContext.Orders.Remove(order);
        }

        public Order GetOrder(int id)
        {
            return dataContext.Orders.Find(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return dataContext.Orders;
        }

        public void Update(Order order)
        {
            dataContext.Entry(order).State = EntityState.Modified;
        }
    }
}
