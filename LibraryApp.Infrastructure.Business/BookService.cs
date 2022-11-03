using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core.Responses.Books;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Infrastructure.Data.Repositories;
using LibraryApp.Services.Interfaces;


namespace LibraryApp.Infrastructure.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookResponse GetBook(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BaseResponse.Failure<BookResponse>(HttpStatusCode.UnprocessableEntity,
                        "Incorrect ID");
                }

                var book = _bookRepository.GetBook(id);

                if (book == null)
                {
                    return BaseResponse.Failure<BookResponse>(HttpStatusCode.NotFound,
                        "Book bot found");
                }

                return new BookResponse { Book = book };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<BookResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public BookCreateResponse CreateBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    return BaseResponse.Failure<BookCreateResponse>(HttpStatusCode.BadRequest,
                        "Incorrect data provided");
                }

                var id = _bookRepository.Create(book);
                _bookRepository.Save();

                return new BookCreateResponse { Id = id };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<BookCreateResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public BooksResponse GetBooks()
        {
            try
            {
                var response = _bookRepository.GetBooks();

                if (response == null || !response.Any())
                {
                    return BaseResponse.Failure<BooksResponse>(HttpStatusCode.NotFound,
                        "Books not found");
                }

                return new BooksResponse { Books = response };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<BooksResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public BaseResponse DeleteBook(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BaseResponse.Failure(HttpStatusCode.BadRequest,
                        "Incorrect ID");
                }

                if (_bookRepository.Delete(id) > 0)
                {
                    _bookRepository.Save();
                    return BaseResponse.Success;
                }

                return BaseResponse.Failure(HttpStatusCode.NotFound,
                    "Book is not found");
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public BaseResponse UpdateBook(Book book)
        {
            try
            {
                if (book == null)
                {
                    return BaseResponse.Failure<BookCreateResponse>(HttpStatusCode.BadRequest,
                        "Incorrect data provided");
                }

                if (_bookRepository.Update(book) > 0)
                {
                    _bookRepository.Save();
                    return BaseResponse.Success;
                }

                return BaseResponse.Failure(HttpStatusCode.NotFound,
                    "Book is not found");
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }
    }
}
