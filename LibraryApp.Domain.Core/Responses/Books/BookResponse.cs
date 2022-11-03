using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses.Books
{
    public class BookResponse : BaseResponse
    {
        public Book Book { get; set; }
    }
}
