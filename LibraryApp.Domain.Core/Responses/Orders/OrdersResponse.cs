using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses.Orders
{
    public class OrdersResponse : BaseResponse
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
