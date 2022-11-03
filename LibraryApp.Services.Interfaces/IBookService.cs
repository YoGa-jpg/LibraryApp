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
        Task<BookCreateResponse> CreateBook(Book user);

        Task<BookResponse> GetBook(int id);

        Task<BaseResponse> UpdateBook(Book user);

        Task<BaseResponse> DeleteBook(int id);

        Task<BooksResponse> GetBooks();
    }
}
