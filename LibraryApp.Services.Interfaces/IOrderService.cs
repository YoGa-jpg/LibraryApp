using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Core.Responses.Orders;

namespace LibraryApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderCreateResponse> CreateOrder(Order order);

        Task<OrderResponse> GetOrder(int id);

        Task<BaseResponse> UpdateOrder(Order order);

        Task<BaseResponse> DeleteOrder(int id);

        Task<OrdersResponse> GetOrders();
    }
}
