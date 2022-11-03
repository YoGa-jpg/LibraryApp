using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses.Readers
{
    public class ReadersResponse : BaseResponse
    {
        public IEnumerable<Reader> Readers { get; set; }
    }
}
