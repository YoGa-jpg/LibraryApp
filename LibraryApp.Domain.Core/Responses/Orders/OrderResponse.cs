using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses.Orders
{
    public class OrderResponse : BaseResponse
    {
        public Order Order { get; set; }
    }
}
