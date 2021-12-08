using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Components
{
    public partial class ErrorComponent
    {
        private string ErrorMessage { get; set; }

        public void Show(string errorMessage)
        {
            ErrorMessage = errorMessage;
            StateHasChanged();
        }

        public void Close()
        {
            ErrorMessage = null;
            StateHasChanged();
        }
    }
}
