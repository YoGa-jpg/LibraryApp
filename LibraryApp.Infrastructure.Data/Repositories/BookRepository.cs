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

        public int? Create(Book book)
        {
            dataContext.Books.Add(book);
            return dataContext.Books.ToList().Last().Id + 1;
        }

        public int? Delete(int id)
        {
            Book book = dataContext.Books.Find(id);
            if (book != null)
                dataContext.Books.Remove(book);
            return book?.Id;
        }

        public Book GetBook(int id)
        {
            return dataContext.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return dataContext.Books;
        }

        public int? Update(Book book)
        {
            dataContext.Entry(book).State = EntityState.Modified;
            return book.Id;
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
