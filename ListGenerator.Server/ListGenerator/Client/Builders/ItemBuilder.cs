using AutoMapper;
using ListGenerator.Shared.Dtos;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListGenerator.Shared.Constants;

namespace ListGenerator.Client.Builders
{
    public class ItemBuilder : IItemBuilder
    {
        private IDateTimeProvider _dateTimeProvider;
        private IMapper _mapper;

        public ItemBuilder(IDateTimeProvider dateTimeProvider, IMapper mapper)
        {
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
        }

        public ItemViewModel BuildItemViewModel()
        {
            var model = new ItemViewModel()
            {
                NextReplenishmentDate = _dateTimeProvider.GetDateTimeNowDate(),
                ReplenishmentPeriodString = "1"
            };

            return model;
        }
    }
}
