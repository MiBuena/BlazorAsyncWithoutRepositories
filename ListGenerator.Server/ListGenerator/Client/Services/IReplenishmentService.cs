using ListGenerator.Shared.Dtos;
using System.Threading.Tasks;
using ListGenerator.Client.Models;
using ListGenerator.Shared.Responses;
using System.Collections.Generic;
using System;

namespace ListGenerator.Client.Services
{
    public interface IReplenishmentService
    {
        Task<Response<IEnumerable<ReplenishmentItemDto>>> GetShoppingListItems(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate);

        Task<BaseResponse> ReplenishItems(ReplenishmentDto replenishmentModel);
    }
}
