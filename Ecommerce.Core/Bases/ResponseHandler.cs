using System.Net;

namespace Ecommerce.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler() { }

        public BaseResponse<T> Success<T>(T data, string message = "Operation Successful")
        {
            return new BaseResponse<T>(data, true, message, HttpStatusCode.OK);
        }

        public BaseResponse<T> Failed<T>(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new BaseResponse<T>(false, message, statusCode);
        }

        public BaseResponse<T> NotFound<T>(string message)
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.NotFound);
        }

        public BaseResponse<T> Unauthorized<T>(string message)
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.Unauthorized);
        }

        public BaseResponse<T> BadRequest<T>(string message)
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.BadRequest);
        }

        public BaseResponse<T> Deleted<T>(string message)
        {
            return new BaseResponse<T>(true, message, HttpStatusCode.OK);
        }

        public BaseResponse<T> Created<T>(T data, string message = "Resource Created")
        {
            return new BaseResponse<T>(data, true, message, HttpStatusCode.Created);
        }

    }
}
