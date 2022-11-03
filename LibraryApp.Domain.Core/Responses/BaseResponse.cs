using System.Net;

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
