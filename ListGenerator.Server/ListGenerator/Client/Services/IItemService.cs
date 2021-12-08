using ListGenerator.Client.Models;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListGenerator.Shared.Responses;

namespace ListGenerator.Client.Services
{
    public interface IItemService
    {
        Task<Response<IEnumerable<ItemNameDto>>> GetItemsNames(string searchWord);
        Task<Response<ItemsOverviewPageDto>> GetItemsOverviewPageModel(int? pageSize, int? skipItems, string orderBy, string searchWord, DateTime? searchDate);
        
        Task<Response<ItemDto>> GetItem(int id);
        
        Task<BaseResponse> AddItem(ItemViewModel item);

        Task<BaseResponse> UpdateItem(ItemViewModel item);

        Task<BaseResponse> DeleteItem(int item);     
    }
}
