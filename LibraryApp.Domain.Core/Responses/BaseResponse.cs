using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Core.Responses
{
    public class BaseResponse
    {
        public DomainResult Result { get; set; } = DomainResult.Success;

        public static T Failure<T>(HttpStatusCode code, string error) where T : BaseResponse, new() =>
            new T
            {
                Result = DomainResult.Failure(code, error)
            };

        public static BaseResponse Failure(HttpStatusCode code, string error) =>
            new BaseResponse()
            {
                Result = DomainResult.Failure(code, error)
            };

        public static BaseResponse Success => new BaseResponse();
    }
}
