using ListGenerator.Client.ViewModels;
using ListGenerator.Data.Entities;
using ListGenerator.Shared.Dtos;
using ListGenerator.Shared.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListGenerator.Web.UnitTests.Helpers
{
    public static class ItemsTestHelper
    {
        public static void InitializeDateTimeProviderMock(Mock<IDateTimeProvider> dateTimeProviderMock)
        {
            var mockDate = new DateTime(2020, 10, 01);
            dateTimeProviderMock.Setup(x => x.GetDateTimeNowDate()).Returns(mockDate);
        }

        public static void InitializeDateTimeProviderMock(Mock<IDateTimeProvider> dateTimeProviderMock, DateTime mockDate)
        {
            dateTimeProviderMock.Setup(x => x.GetDateTimeNowDate()).Returns(mockDate);
        }

        public static ItemDto BuildItemDto(DateTime nextReplenishmentDate)
        {
            var itemDto = new ItemDto()
            {
                Id = 1,
                Name = "Bread",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentPeriod = 1
            };

            return itemDto;
        }

        public static PurchaseItemViewModel BuildPurchaseItemViewModel(DateTime nextReplenishmentDate)
        {
            var purchaseItemViewModel = new PurchaseItemViewModel()
            {
                ItemId = 1,
                Name = "Bread",
                NextReplenishmentDate = nextReplenishmentDate,
            };

            return purchaseItemViewModel;
        }

        public static List<PurchaseItemViewModel> BuildNonUrgentPurchaseItemVMCollection()
        {
            var purchaseItemViewModel = BuildNonUrgentPurchaseItemViewModel();

            var purchaseItemVMCollection = new List<PurchaseItemViewModel>();
            purchaseItemVMCollection.Add(purchaseItemViewModel);

            return purchaseItemVMCollection;
        }

        public static bool HaveTheSameElements(IEnumerable<Item> firstCollection, IEnumerable<Item> secondCollection)
        {
            if (firstCollection.Count() != secondCollection.Count())
            {
                return false;
            }

            var a = firstCollection.ToList();
            var b = secondCollection.ToList();

            bool areEqual = true;

            for (int i = 0; i < a.Count; i++)
            {
                var p = a[i];
                var l = b[i];

                if (p.Id != l.Id
                    || p.Name != l.Name
                    || p.NextReplenishmentDate != l.NextReplenishmentDate
                    || p.ReplenishmentPeriod != l.ReplenishmentPeriod
                    || p.UserId != l.UserId)
                {
                    areEqual = false;
                    return areEqual;
                }
            }

            return areEqual;
        }

        public static bool HaveTheSameProperties(string userId, ItemDto itemDto, Item item)
        {
            var haveTheSameProperties = item.Id == itemDto.Id
            && item.Name == itemDto.Name
            && item.NextReplenishmentDate == itemDto.NextReplenishmentDate
            && item.ReplenishmentPeriod == itemDto.ReplenishmentPeriod
            && item.UserId == userId;

            return haveTheSameProperties;
        }

        public static IEnumerable<ItemDto> BuildItemsDtosCollection()
        {
            var collection = new List<ItemDto>();

            var firstItem = new ItemDto()
            {
                Id = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 06),
                ReplenishmentPeriod = 1
            };

            var secondItem = new ItemDto()
            {
                Id = 2,
                Name = "Cheese",
                NextReplenishmentDate = new DateTime(2020, 10, 08),
                ReplenishmentPeriod = 2
            };

            var thirdItem = new ItemDto()
            {
                Id = 3,
                Name = "Biscuits",
                NextReplenishmentDate = new DateTime(2020, 10, 07),
                ReplenishmentPeriod = 5
            };

            var fourthItem = new ItemDto()
            {
                Id = 4,
                Name = "Oats",
                NextReplenishmentDate = new DateTime(2020, 10, 1),
                ReplenishmentPeriod = 7
            };

            var fifthItem = new ItemDto()
            {
                Id = 5,
                Name = "Cake",
                NextReplenishmentDate = new DateTime(2020, 10, 2),
                ReplenishmentPeriod = 5
            };

            collection.Add(firstItem);
            collection.Add(secondItem);
            collection.Add(thirdItem);
            collection.Add(fourthItem);
            collection.Add(fifthItem);

            return collection;
        }

        public static List<PurchaseItemViewModel> BuildPurchaseItemsViewModelsCollection()
        {
            var collection = new List<PurchaseItemViewModel>();

            var firstItem = new PurchaseItemViewModel()
            {
                ItemId = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 06),
                Quantity = "5",
                ReplenishmentDate = new DateTime(2020, 10, 01),
                ReplenishmentSignalClass = string.Empty
            };

            var secondItem = new PurchaseItemViewModel()
            {
                ItemId = 2,
                Name = "Cheese",
                NextReplenishmentDate = new DateTime(2020, 10, 08),
                Quantity = "2",
                ReplenishmentDate = new DateTime(2020, 10, 01),
                ReplenishmentSignalClass = string.Empty
            };

            var thirdItem = new PurchaseItemViewModel()
            {
                ItemId = 3,
                Name = "Biscuits",
                NextReplenishmentDate = new DateTime(2020, 10, 07),
                Quantity = "1",
                ReplenishmentDate = new DateTime(2020, 10, 01),
                ReplenishmentSignalClass = string.Empty
            };

            var fourthItem = new PurchaseItemViewModel()
            {
                ItemId = 4,
                Name = "Oats",
                NextReplenishmentDate = new DateTime(2020, 10, 1),
                Quantity = "2",
                ReplenishmentDate = new DateTime(2020, 10, 01),
                ReplenishmentSignalClass = "itemNeedsReplenishment"
            };

            var fifthItem = new PurchaseItemViewModel()
            {
                ItemId = 5,
                Name = "Cake",
                NextReplenishmentDate = new DateTime(2020, 10, 2),
                Quantity = "2",
                ReplenishmentDate = new DateTime(2020, 10, 01),
                ReplenishmentSignalClass = "itemNeedsReplenishment"
            };

            collection.Add(firstItem);
            collection.Add(secondItem);
            collection.Add(thirdItem);
            collection.Add(fourthItem);
            collection.Add(fifthItem);

            return collection;
        }

        public static IEnumerable<ItemDto> BuildNonUrgentItemDtoCollection()
        {
            var itemDto = BuildNotUrgentItemDto();

            var itemDtoCollection = new List<ItemDto>();
            itemDtoCollection.Add(itemDto);

            return itemDtoCollection;
        }

        public static PurchaseItemViewModel BuildNonUrgentPurchaseItemViewModel()
        {
            var purchaseItem = new PurchaseItemViewModel()
            {
                ItemId = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 06),
            };

            return purchaseItem;
        }

        public static ItemDto BuildNotUrgentItemDto()
        {
            var item = new ItemDto()
            {
                Id = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 06),
                ReplenishmentPeriod = 1
            };

            return item;
        }

        public static List<PurchaseItemViewModel> BuildUrgentPurchaseItemVMCollection()
        {
            var purchaseItemViewModel = BuildUrgentPurchaseItemViewModel();

            var purchaseItemVMCollection = new List<PurchaseItemViewModel>();
            purchaseItemVMCollection.Add(purchaseItemViewModel);

            return purchaseItemVMCollection;
        }

        public static IEnumerable<ItemDto> BuildUrgentItemDtoCollection()
        {
            var itemDto = BuildUrgentItemDto();

            var itemDtoCollection = new List<ItemDto>();
            itemDtoCollection.Add(itemDto);

            return itemDtoCollection;
        }

        public static ItemDto BuildUrgentItemDto()
        {
            var item = new ItemDto()
            {
                Id = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 02),
                ReplenishmentPeriod = 1
            };

            return item;
        }

        public static PurchaseItemViewModel BuildUrgentPurchaseItemViewModel()
        {
            var purchaseItem = new PurchaseItemViewModel()
            {
                ItemId = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 02),
            };

            return purchaseItem;
        }
    }
}
