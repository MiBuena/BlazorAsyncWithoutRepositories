using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
