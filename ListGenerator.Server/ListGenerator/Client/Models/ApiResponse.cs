using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Client.Models
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }

        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }
    }
}
