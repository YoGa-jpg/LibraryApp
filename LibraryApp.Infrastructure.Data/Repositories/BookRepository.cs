using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private DataContext dataContext;

        public BookRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(Book book)
        {
            dataContext.Books.Add(book);
        }

        public void Delete(int id)
        {
            Book book = dataContext.Books.Find(id);
            if (book != null)
                dataContext.Books.Remove(book);
        }

        public Book GetBook(int id)
        {
            return dataContext.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return dataContext.Books;
        }

        public void Update(Book book)
        {
            dataContext.Entry(book).State = EntityState.Modified;
        }
    }
}
