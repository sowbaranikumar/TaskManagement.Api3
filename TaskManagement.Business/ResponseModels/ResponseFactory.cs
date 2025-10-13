using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

namespace TaskManagement.Business.ResponseModels
{
    public static class ApiResponseFactory
    {
        public static GenericAPIResponse<T> Success<T>(T response)

        {
            return new GenericAPIResponse<T>
            {
                StatusCode=(int)HttpStatusCode.OK,
                StatusMsg="Success",
                ErrorMsg=[],
                Response=response
            };
        }
    public static GenericAPIResponse<T>Created<T>(T response)
        {
            return new GenericAPIResponse<T>
            {
                StatusCode = (int)HttpStatusCode.Created,
                StatusMsg = "Created",
                ErrorMsg = [],
                Response = response
            };
        }

        public static GenericAPIResponse<T>BadRequest<T>(List<string> errorMsgs)
        {
            return new GenericAPIResponse<T>
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                StatusMsg = "Bad Request",
                ErrorMsg = errorMsgs
            };
        }

        public static GenericAPIResponse<T> NotFound<T>(List<string>? errorMsgs = null)
        {
            return new GenericAPIResponse<T>
            {
                StatusCode=(int)HttpStatusCode.NotFound,
                StatusMsg="Not Found",
                ErrorMsg=errorMsgs??new List<string>{"The requested resource was not found."}
            };
        }
    }
}

