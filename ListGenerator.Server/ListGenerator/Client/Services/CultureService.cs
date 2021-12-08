using ListGenerator.Client.Interfaces;
using ListGenerator.Shared.Responses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Services
{
    public class CultureService : ICultureService
    {
        private NavigationManager _navigationManager;
        private IApiClient _apiClient;

        public CultureService(NavigationManager navigationManager, IApiClient apiClient)
        {
            _navigationManager = navigationManager;
            _apiClient = apiClient;
        }

        public async Task<BaseResponse> ChangeCulture(string culture)
        {
            var query = $"?culture={Uri.EscapeDataString(culture)}";

            var response = await _apiClient.GetAsync<BaseResponse>($"api/culture/setculture/{query}");

            return response;
        }
    }
}
