using LibraryApp.Domain.Core;

namespace LibraryApp.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task<int?> Create(Order order);
        Task<int?> Update(Order order);
        Task<int?> Delete(int id);
        Task Save();
    }
}
