﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses.Books
{
    public class BooksResponse : BaseResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }
}