using ListGenerator.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ListGenerator.Client.Handlers
{
    public class BlazorDisplaySpinnerAutomaticallyHttpMessageHandler : BaseAddressAuthorizationMessageHandler
    {
        private readonly ISpinnerService _spinnerService;

        public BlazorDisplaySpinnerAutomaticallyHttpMessageHandler(ISpinnerService spinnerService, IAccessTokenProvider provider, NavigationManager manager) : base(provider, manager)
        {
            _spinnerService = spinnerService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _spinnerService.Show();
            var response = await base.SendAsync(request, cancellationToken);
            _spinnerService.Hide();
            return response;
        }
    }
}
