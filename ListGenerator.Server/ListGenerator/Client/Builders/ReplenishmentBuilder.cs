using AutoMapper;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListGenerator.Client.Builders
{
    public class ReplenishmentBuilder : IReplenishmentBuilder
    {
        private readonly IMapper _mapper;

        public ReplenishmentBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ReplenishmentDto BuildReplenishmentDto(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate, PurchaseItemViewModel viewModel)
        {
            var dto = _mapper.Map<PurchaseItemViewModel, PurchaseItemDto>(viewModel);

            var replenishmentModel = GetReplenishmentDtoWithBasicProperties(firstReplenishmentDate, secondReplenishmentDate);

            replenishmentModel.Purchaseitems.Add(dto);
            return replenishmentModel;
        }

        public ReplenishmentDto BuildReplenishmentDto(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate, List<PurchaseItemViewModel> viewModels)
        {
            var replenishmentModel = GetReplenishmentDtoWithBasicProperties(firstReplenishmentDate, secondReplenishmentDate);

            replenishmentModel.Purchaseitems = viewModels.Select(x => _mapper.Map<PurchaseItemViewModel, PurchaseItemDto>(x)).ToList();

            return replenishmentModel;
        }

        private ReplenishmentDto GetReplenishmentDtoWithBasicProperties(DateTime firstReplenishmentDate, DateTime secondReplenishmentDate)
        {
            var replenishmentModel = new ReplenishmentDto()
            {
                FirstReplenishmentDate = firstReplenishmentDate,
                SecondReplenishmentDate = secondReplenishmentDate
            };

            return replenishmentModel;
        }
    }
}
