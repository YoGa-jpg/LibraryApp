namespace LibraryApp.Domain.Core
{
    public class Reader
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public List<Order>? Orders { get; set; }
    }
}
