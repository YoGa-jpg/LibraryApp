namespace LibraryApp.Domain.Core.Responses.Readers
{
    public class ReadersResponse : BaseResponse
    {
        public IEnumerable<Reader> Readers { get; set; }
    }
}
