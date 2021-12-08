using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Responses
{
    public class Response<T> : BaseResponse
    {
        public T Data { get; set; }
    } 
}
