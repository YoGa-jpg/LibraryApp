using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Core.Responses.Readers;

namespace LibraryApp.Services.Interfaces
{
    public interface IReaderService
    {
        Task<ReaderCreateResponse> CreateReader(Reader reader);

        Task<ReaderResponse> GetReader(int id);

        Task<BaseResponse> UpdateReader(Reader reader);

        Task<BaseResponse> DeleteReader(int id);

        Task<ReadersResponse> GetReaders();
    }
}
