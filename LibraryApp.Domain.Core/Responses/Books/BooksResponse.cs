namespace LibraryApp.Domain.Core.Responses.Books
{
    public class BooksResponse : BaseResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
