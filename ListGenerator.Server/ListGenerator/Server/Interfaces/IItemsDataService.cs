using ListGenerator.Shared.Dtos;
using ListGenerator.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListGenerator.Server.Interfaces
{
    public interface IItemsDataService
    {
        Task<Response<IEnumerable<ItemNameDto>>> GetItemsNames(string searchWord, string userId);

        Response<ItemDto> GetItem(int itemId, string userId);

        BaseResponse AddItem(string userId, ItemDto itemDto);

        BaseResponse UpdateItem(string userId, ItemDto itemDto);

        BaseResponse DeleteItem(int id, string userId);

        Response<ItemsOverviewPageDto> GetItemsOverviewPageModel(string userId, FilterPatemetersDto dto);
    }
}
