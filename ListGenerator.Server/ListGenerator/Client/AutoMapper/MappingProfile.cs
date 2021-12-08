using AutoMapper;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;
using System;
using ListGenerator.Shared.Constants;

namespace ListGenerator.Client.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemOverviewDto, ItemOverviewViewModel>()
                .ForMember(item => item.ReplenishmentPeriodString, opt => opt.MapFrom(a => a.ReplenishmentPeriod.ToString()))
                .ForMember(item => item.ReplenishmentPeriod, opt => opt.MapFrom(a => a.ReplenishmentPeriod))
                .ReverseMap()
                .ForPath(s => s.ReplenishmentPeriod, opt => opt.MapFrom(src => double.Parse(src.ReplenishmentPeriodString)));

            CreateMap<ItemDto, ItemViewModel>()
                .ForMember(item => item.ReplenishmentPeriodString, opt => opt.MapFrom(a => a.ReplenishmentPeriod.ToString()))
                .ForMember(item => item.ReplenishmentPeriod, opt => opt.MapFrom(a => a.ReplenishmentPeriod))
                .ReverseMap()
                .ForPath(s => s.ReplenishmentPeriod, opt => opt.MapFrom(src => double.Parse(src.ReplenishmentPeriodString)));

            CreateMap<ItemDto, PurchaseItemViewModel>()
                .ForMember(item => item.ItemId, opt => opt.MapFrom(a => a.Id));

            CreateMap<PurchaseItemViewModel, PurchaseItemDto>()
                .ForMember(item => item.Quantity, opt => opt.MapFrom(a => int.Parse(a.Quantity)));

            CreateMap<ReplenishmentItemDto, PurchaseItemViewModel>()
                .ForMember(item => item.ItemId, opt => opt.MapFrom(a => a.Id))
                .ForMember(item => item.Quantity, opt => opt.MapFrom(a => a.Quantity.ToString()))
                .ForMember(item => item.ReplenishmentSignalClass, 
                opt => opt.MapFrom(a => a.ItemNeedsReplenishmentUrgently 
                ? Constants.ReplenishmentSignalClass 
                : string.Empty));
        }
    }
}