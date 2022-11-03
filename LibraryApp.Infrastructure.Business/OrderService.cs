using LibraryApp.Domain.Core;
using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core.Responses.Orders;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Services.Interfaces;
using System.Net;

namespace LibraryApp.Infrastructure.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderCreateResponse> CreateOrder(Order order)
        {
            try
            {
                if (order == null)
                {
                    return BaseResponse.Failure<OrderCreateResponse>(HttpStatusCode.BadRequest,
                        "Incorrect data provided");
                }

                var id = await _orderRepository.Create(order);
                await _orderRepository.Save();

                return new OrderCreateResponse { Id = id };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<OrderCreateResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<BaseResponse> DeleteOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BaseResponse.Failure(HttpStatusCode.BadRequest,
                        "Incorrect ID");
                }

                if (await _orderRepository.Delete(id) > 0)
                {
                    await _orderRepository.Save();
                    return BaseResponse.Success;
                }

                return BaseResponse.Failure(HttpStatusCode.NotFound,
                    "Order is not found");
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<OrderResponse> GetOrder(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BaseResponse.Failure<OrderResponse>(HttpStatusCode.UnprocessableEntity,
                        "Incorrect ID");
                }

                var order = await _orderRepository.GetOrder(id);

                if (order == null)
                {
                    return BaseResponse.Failure<OrderResponse>(HttpStatusCode.NotFound,
                        "Order not found");
                }

                return new OrderResponse { Order = order };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<OrderResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<OrdersResponse> GetOrders()
        {
            try
            {
                var response = await _orderRepository.GetOrders();

                if (response == null || !response.Any())
                {
                    return BaseResponse.Failure<OrdersResponse>(HttpStatusCode.NotFound,
                        "Orders not found");
                }

                return new OrdersResponse { Orders = response };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<OrdersResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<BaseResponse> UpdateOrder(Order order)
        {
            try
            {
                if (order == null)
                {
                    return BaseResponse.Failure<OrderCreateResponse>(HttpStatusCode.BadRequest,
                        "Incorrect data provided");
                }

                if (await _orderRepository.Update(order) > 0)
                {
                    await _orderRepository.Save();
                    return BaseResponse.Success;
                }

                return BaseResponse.Failure(HttpStatusCode.NotFound,
                    "Order is not found");
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }
    }
}
