using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Bases
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public BaseResponse()
        {
            
        }

        public BaseResponse(bool issuccess, string message, HttpStatusCode statuscode)
        {
            IsSuccess = issuccess;
            Message = message;
            StatusCode = statuscode;
        }

        public BaseResponse(bool issuccess, string message, HttpStatusCode statuscode, string statusMessage)
        {
            IsSuccess = issuccess;
            Message = message;
            StatusCode = statuscode;
            StatusMessage = statusMessage;
        }

        public BaseResponse(T data, bool issuccess, string message, HttpStatusCode statuscode)
        {
            Data = data;
            IsSuccess = issuccess;
            Message = message;
            StatusCode = statuscode;
        }

    }
}
