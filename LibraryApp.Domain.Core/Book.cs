namespace LibraryApp.Domain.Core
{
    public class Book
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
