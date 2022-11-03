using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core.Responses.Books;

namespace LibraryApp.Services.Interfaces
{
    public interface IBookService
    {
        BookCreateResponse CreateBook(Book user);

        BookResponse GetBook(int id);

        BaseResponse UpdateBook(Book user);

        BaseResponse DeleteBook(int id);

        BooksResponse GetBooks();
    }
}
