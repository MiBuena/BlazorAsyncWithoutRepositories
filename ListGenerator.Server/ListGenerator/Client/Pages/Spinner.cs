using ListGenerator.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Pages
{
    public partial class Spinner
    {
        [Inject]
        private ISpinnerService SpinnerService { get; set; }

        private bool IsVisible { get; set; }

        protected override void OnInitialized()
        {
            SpinnerService.OnShow += ShowSpinner;
            SpinnerService.OnHide += HideSpinner;
        }

        public void ShowSpinner()
        {
            IsVisible = true;
            StateHasChanged();
        }

        public void HideSpinner()
        {
            IsVisible = false;
            StateHasChanged();
        }
    }
}
