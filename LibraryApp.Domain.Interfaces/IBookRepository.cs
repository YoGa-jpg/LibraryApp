using LibraryApp.Domain.Core;

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
