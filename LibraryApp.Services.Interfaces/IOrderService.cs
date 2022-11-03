using LibraryApp.Domain.Core.Responses.Readers;
using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
