using LibraryApp.Domain.Core;
using LibraryApp.Domain.Core.Responses;
using LibraryApp.Domain.Core.Responses.Books;
using LibraryApp.Domain.Core.Responses.Readers;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data.Repositories;
using LibraryApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Business
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task<ReaderCreateResponse> CreateReader(Reader reader)
        {
            try
            {
                if (reader == null)
                {
                    return BaseResponse.Failure<ReaderCreateResponse>(HttpStatusCode.BadRequest,
                        "Incorrect data provided");
                }

                var id = await _readerRepository.Create(reader);
                await _readerRepository.Save();

                return new ReaderCreateResponse { Id = id };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<ReaderCreateResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<BaseResponse> DeleteReader(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BaseResponse.Failure(HttpStatusCode.BadRequest,
                        "Incorrect ID");
                }

                if (await _readerRepository.Delete(id) > 0)
                {
                    await _readerRepository.Save();
                    return BaseResponse.Success;
                }

                return BaseResponse.Failure(HttpStatusCode.NotFound,
                    "Reader is not found");
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<ReaderResponse> GetReader(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BaseResponse.Failure<ReaderResponse>(HttpStatusCode.UnprocessableEntity,
                        "Incorrect ID");
                }

                var reader = await _readerRepository.GetReader(id);

                if (reader == null)
                {
                    return BaseResponse.Failure<ReaderResponse>(HttpStatusCode.NotFound,
                        "Reader not found");
                }

                return new ReaderResponse { Reader = reader };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<ReaderResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<ReadersResponse> GetReaders()
        {
            try
            {
                var response = await _readerRepository.GetReaders();

                if (response == null || !response.Any())
                {
                    return BaseResponse.Failure<ReadersResponse>(HttpStatusCode.NotFound,
                        "Readers not found");
                }

                return new ReadersResponse { Readers = response };
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure<ReadersResponse>(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<BaseResponse> UpdateReader(Reader reader)
        {
            try
            {
                if (reader == null)
                {
                    return BaseResponse.Failure<BookCreateResponse>(HttpStatusCode.BadRequest,
                        "Incorrect data provided");
                }

                if (await _readerRepository.Update(reader) > 0)
                {
                    await _readerRepository.Save();
                    return BaseResponse.Success;
                }

                return BaseResponse.Failure(HttpStatusCode.NotFound,
                    "Reader is not found");
            }
            catch (Exception ex)
            {
                return BaseResponse.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }
    }
}
