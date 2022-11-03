using LibraryApp.Domain.Core.Responses.Books;
using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
