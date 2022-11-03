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

        public async Task<int?> Create(Book book)
        {
            await dataContext.Books.AddAsync(book);
            return dataContext.Books.ToList().Last().Id + 1;
        }

        public async Task<int?> Delete(int id)
        {
            Book book = await dataContext.Books.FindAsync(id);
            if (book != null)
                dataContext.Books.Remove(book);
            return book?.Id;
        }

        public async Task<Book> GetBook(int id)
        {
            return await dataContext.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await Task.Run(() => dataContext.Books);
            return books;
        }

        public async Task<int?> Update(Book book)
        {
            await Task.Run(() => dataContext.Entry(book).State = EntityState.Modified);
            return book.Id;
        }

        public async void Save()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
