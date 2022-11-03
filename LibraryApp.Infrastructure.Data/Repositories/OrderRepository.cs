using Microsoft.EntityFrameworkCore;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext dataContext;

        public OrderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<int?> Create(Order order)
        {
            await dataContext.Orders.AddAsync(order);
            return dataContext.Orders.Count() > 0 ? (dataContext.Orders.ToList().Last().Id + 1) : 1;
        }
        public async Task<int?> Delete(int id)
        {
            Order order = await dataContext.Orders.FindAsync(id);
            if (order != null)
                dataContext.Orders.Remove(order);
            return order?.Id;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await dataContext.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await Task.Run(() => dataContext.Orders);
            return orders;
        }

        public async Task<int?> Update(Order order)
        {
            await Task.Run(() => dataContext.Entry(order).State = EntityState.Modified);
            return order.Id;
        }

        public async Task Save()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
