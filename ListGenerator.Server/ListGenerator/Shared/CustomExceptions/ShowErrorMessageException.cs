using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Shared.CustomExceptions
{
    public class ShowErrorMessageException : Exception
    {
        public ShowErrorMessageException(string message) : base(message)
        {
        }
    }
}
