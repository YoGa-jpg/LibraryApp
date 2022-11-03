using LibraryApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<int?> Create(Book book);
        Task<int?> Update(Book book);
        Task<int?> Delete(int id);
        Task Save();
    }
}
