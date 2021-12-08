using ListGenerator.Client.Interfaces;
using ListGenerator.Client.Models;
using ListGenerator.Client.Services;
using ListGenerator.Shared.Responses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Pages
{
    public partial class ChangeLanguage
    {
        [Inject]
        private ICultureService CultureService { get; set; }

        [Parameter]
        public EventCallback<bool> ChangeEventCallBack { get; set; }

        private async void OnSelected(ChangeEventArgs e)
        {
            var culture = (string)e.Value;
            await CultureService.ChangeCulture(culture);
            await ChangeEventCallBack.InvokeAsync(true);
        }
    }
}
