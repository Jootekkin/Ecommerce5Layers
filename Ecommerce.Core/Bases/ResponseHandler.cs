using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler() { }

        public BaseResponse<T> Success<T>(T data, string message = "Operation Successful")
        {
            return new BaseResponse<T>(data, true, message, HttpStatusCode.OK);
        }

        public BaseResponse<T> Failed<T>(string message = "Operation Failed", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new BaseResponse<T>(false, message, statusCode);
        }

        public BaseResponse<T> NotFound<T>(string message = "Resource Not Found")
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.NotFound);
        }

        public BaseResponse<T> Unauthorized<T>(string message = "Unauthorized Access")
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.Unauthorized);
        }

        public BaseResponse<T> InternalError<T>(string message = "Internal Server Error")
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.InternalServerError);
        }

        public BaseResponse<T> BadRequest<T>(string message = "Bad Request")
        {
            return new BaseResponse<T>(false, message, HttpStatusCode.BadRequest);
        }

        public BaseResponse<T> Deleted<T>(string message = "Resource Deleted")
        {
            return new BaseResponse<T>(true, message, HttpStatusCode.OK);
        }

        public BaseResponse<T> Created<T>(T data, string message = "Resource Created")
        {
            return new BaseResponse<T>(data, true, message, HttpStatusCode.Created);
        }

        public BaseResponse<T> HandleException<T>(string exceptionMessage, string userMessage = "An error occurred")
        {
            // Log the exception message here if needed
            return new BaseResponse<T>(false, userMessage, HttpStatusCode.InternalServerError, exceptionMessage);
        }
    }
}
