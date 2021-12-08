using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;

namespace ListGenerator.Client.Builders
{
    public interface IReplenishmentBuilder
    {
        ReplenishmentDto BuildReplenishmentDto(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate, PurchaseItemViewModel viewModel);
        
        ReplenishmentDto BuildReplenishmentDto(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate, List<PurchaseItemViewModel> viewModels);
    }
}
