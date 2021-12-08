using AutoMapper;
using ListGenerator.Client.Models;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListGenerator.Client.Interfaces;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Shared.Enums;
using ListGenerator.Shared.Constants;
using ListGenerator.Shared.Helpers;
using ListGenerator.Shared.Responses;

namespace ListGenerator.Client.Services
{
    public class ItemService : IItemService
    {
        private readonly IApiClient _apiClient;
        private readonly IJsonHelper _jsonHelper;
        private readonly IMapper _mapper;

        public ItemService(IApiClient apiClient, IJsonHelper jsonHelper, IMapper mapper)
        {
            _apiClient = apiClient;
            _jsonHelper = jsonHelper;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ItemNameDto>>> GetItemsNames(string searchWord)
        {
            var response = await _apiClient.GetAsync<Response<IEnumerable<ItemNameDto>>>($"api/items/itemsnames/{searchWord}");
            return response;
        }

        public async Task<Response<ItemsOverviewPageDto>> GetItemsOverviewPageModel(int? pageSize, int? skipItems, string orderBy, string searchWord, DateTime? searchDate)
        {
            var sortingData = GetSortingData(orderBy);

            var dateToString = DateTimeHelper.ToTransferDateAsString(searchDate);    

            var response = await _apiClient.GetAsync<Response<ItemsOverviewPageDto>>($"api/items/overview/?PageSize={pageSize}&SkipItems={skipItems}&OrderByColumn={sortingData.OrderByColumn}&OrderByDirection={sortingData.OrderByDirection}&SearchWord={searchWord}&SearchDate={dateToString}");

            return response;
        }

        private SortingData GetSortingData(string orderBy)
        {
            var sortingData = new SortingData();

            if (orderBy != null)
            {
                sortingData.OrderByColumn = orderBy.Split(" ")[0];

                sortingData.OrderByDirection = orderBy.Split(" ")[1] == Constants.GridAscendingKeyword
                    ? SortingDirection.Ascending 
                    : sortingData.OrderByDirection = SortingDirection.Descending;
            }

            return sortingData;
        }

        public async Task<Response<ItemDto>> GetItem(int id)
        {
            var response = await _apiClient.GetAsync<Response<ItemDto>>($"api/items/{id}");
            return response;
        }

        public async Task<BaseResponse> AddItem(ItemViewModel item)
        {
            var itemDto = _mapper.Map<ItemViewModel, ItemDto>(item);

            var itemJson = _jsonHelper.Serialize(itemDto);

            var response = await _apiClient.PostAsync("api/items", itemJson);

            return response;
        }

        public async Task<BaseResponse> UpdateItem(ItemViewModel item)
        {
            var itemDto = _mapper.Map<ItemViewModel, ItemDto>(item);

            var itemJson = _jsonHelper.Serialize(itemDto);

            var response = await _apiClient.PutAsync("api/items", itemJson);

            return response;
        }

        public async Task<BaseResponse> DeleteItem(int itemId)
        {
            var response = await _apiClient.DeleteAsync($"api/items/{itemId}");
            return response;
        }
    }
}
