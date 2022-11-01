using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core
{
    public class Order
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int BookId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
