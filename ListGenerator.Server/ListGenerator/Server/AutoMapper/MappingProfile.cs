using AutoMapper;
using ListGenerator.Data.Entities;
using ListGenerator.Shared.Dtos;
using ListGenerator.Client.ViewModels;

namespace ListGenerator.Server.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemDto, Item>()
                .ReverseMap();

            CreateMap<PurchaseItemDto, Purchase>();

            CreateMap<Item, ItemNameDto>();

            CreateMap<Item, ReplenishmentItemDto>();
        }
    }
}