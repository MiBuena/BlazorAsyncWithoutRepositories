using AutoMapper;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Shared.Dtos;
using System.Threading.Tasks;
using ListGenerator.Client.Interfaces;
using ListGenerator.Client.Models;
using ListGenerator.Client.Services;
using ListGenerator.Shared.Responses;
using System.Collections.Generic;
using ListGenerator.Shared.Helpers;
using System;

namespace ListGenerator.Client.Services
{
    public class ReplenishmentService : IReplenishmentService
    {
        private readonly IApiClient _apiClient;
        private readonly IJsonHelper _jsonHelper;

        public ReplenishmentService(IApiClient apiClient, IJsonHelper jsonHelper)
        {
            _apiClient = apiClient;
            _jsonHelper = jsonHelper;
        }


        public async Task<Response<IEnumerable<ReplenishmentItemDto>>> GetShoppingListItems(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate)
        {
            var firstReplenishmentDateTransfer = DateTimeHelper.ToTransferDateAsString(firstReplenishmentDate);
            var secondReplenishmentDateTransfer = DateTimeHelper.ToTransferDateAsString(secondReplenishmentDate);
            var response = await _apiClient.GetAsync<Response<IEnumerable<ReplenishmentItemDto>>>($"api/replenishment/shoppinglist/{firstReplenishmentDateTransfer}/{secondReplenishmentDateTransfer}");

            return response;
        }

        public async Task<BaseResponse> ReplenishItems(ReplenishmentDto replenishmentModel)
        {
            var replenishmentJson = _jsonHelper.Serialize(replenishmentModel);

            var response = await _apiClient.PostAsync("api/replenishment/replenish", replenishmentJson);

            return response;
        }
    }
}
