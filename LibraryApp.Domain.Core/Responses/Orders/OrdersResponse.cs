namespace LibraryApp.Domain.Core.Responses.Orders
{
    public class OrdersResponse : BaseResponse
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
