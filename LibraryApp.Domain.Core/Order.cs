namespace LibraryApp.Domain.Core
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int? ReaderId { get; set; }
        public Reader? Reader { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
    }
}
