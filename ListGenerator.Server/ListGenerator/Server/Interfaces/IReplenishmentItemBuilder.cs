using ListGenerator.Data.Entities;
using ListGenerator.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Server.Interfaces
{
    public interface IReplenishmentItemBuilder
    {
        IEnumerable<ReplenishmentItemDto> BuildReplenishmentItemsDtos(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate, IEnumerable<Item> items);
    }
}
