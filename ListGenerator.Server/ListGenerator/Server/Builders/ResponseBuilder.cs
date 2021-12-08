using ListGenerator.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Server.Builders
{
    public static class ResponseBuilder
    {
        public static Response<T>Success<T>(T data = null) where T : class
        {
            var response = new Response<T>()
            {
                IsSuccess = true,
                Data = data,
            };

            return response;
        }

        public static Response<T> Failure<T>(string errorMessage = null) where T : class
        {
            var response = new Response<T>()
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
            };

            return response;
        }

        public static BaseResponse Success()    
        {
            var response = new BaseResponse()
            {
                IsSuccess = true,
            };

            return response;
        }

        public static BaseResponse Failure(string errorMessage = null)
        {
            var response = new BaseResponse()
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
            };

            return response;
        }
    }
}
