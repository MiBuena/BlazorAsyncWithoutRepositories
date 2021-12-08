using IdentityModel.Client;
using ListGenerator.Client.ViewModels;
using ListGenerator.Data.Entities;
using ListGenerator.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListGenerator.Web.UnitTests
{
    public class BaseItemsTests
    {       
        protected IQueryable<Item> BuildItemsCollection()
        {
            var collection = new List<Item>();

            var firstItem = BuildFirstItem();
            var secondItem = BuildSecondItem();
            var thirdItem = BuildThirdItem();

            var fourthItem = new Item()
            {
                Id = 4,
                Name = "Oats",
                NextReplenishmentDate = new DateTime(2020, 10, 1),
                ReplenishmentPeriod = 7,
                UserId = "925912b0-c59c-4e1b-971a-06e8abab7848"
            };

            var fifthItem = new Item()
            {
                Id = 5,
                Name = "Cake",
                NextReplenishmentDate = new DateTime(2020, 10, 2),
                ReplenishmentPeriod = 5,
                UserId = "925912b0-c59c-4e1b-971a-06e8abab7848"
            };

            collection.Add(firstItem);
            collection.Add(secondItem);
            collection.Add(thirdItem);
            collection.Add(fourthItem);
            collection.Add(fifthItem);

            return collection.AsQueryable();
        }

        protected Item BuildThirdItem()
        {
            var purchases = BuildThirdItemPurchases();

            var thirdItem = new Item()
            {
                Id = 3,
                Name = "Biscuits",
                NextReplenishmentDate = new DateTime(2020, 10, 07),
                ReplenishmentPeriod = 5,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0",
                Purchases = purchases
            };

            return thirdItem;
        }
        private ICollection<Purchase> BuildThirdItemPurchases()
        {
            var firstPurchase = new Purchase()
            {
                ReplenishmentDate = new DateTime(2020, 10, 02),
                Quantity = 1,
                ItemId = 3
            };

            var list = new List<Purchase>() { firstPurchase };
            return list;
        }

        protected Item BuildSecondItem()
        {
            var secondItem = new Item()
            {
                Id = 2,
                Name = "Cheese",
                NextReplenishmentDate = new DateTime(2020, 10, 08),
                ReplenishmentPeriod = 2,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0"
            };

            return secondItem;
        }

        protected Item BuildFirstItem()
        {
            var firstItemPurchases = BuildFirstItemPurchases();

            var firstItem = new Item()
            {
                Id = 1,
                Name = "Bread",
                NextReplenishmentDate = new DateTime(2020, 10, 06),
                ReplenishmentPeriod = 1,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0",
                Purchases = firstItemPurchases
            };

            return firstItem;
        }


        private ICollection<Purchase> BuildFirstItemPurchases()
        {
            var firstPurchase = new Purchase()
            {
                ReplenishmentDate = new DateTime(2020, 10, 01),
                Quantity = 2,
                ItemId = 1
            };

            var secondPurchase = new Purchase()
            {
                ReplenishmentDate = new DateTime(2020, 10, 03),
                Quantity = 3,
                ItemId = 1
            };

            var list = new List<Purchase>() { firstPurchase, secondPurchase };
            return list;
        }

        public IQueryable<ReplenishmentItemDto> BuildDifferentDatesItemsDtosCollection()
        {
            var urgentItem = BuildUrgentReplenishmentItemDto(new DateTime(2020, 10, 02));
            var nonUrgentItem = BuildNonUrgentReplenishmentItemDto(new DateTime(2020, 10, 06));
            var itemWithNextReplDateOnFirstReplDate = BuildItemDtoWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));
            var itemNotInShoppingList = BuildOutOfShoppingListReplenishmentItemDto(new DateTime(2020, 10, 20));

            var collection = new List<ReplenishmentItemDto>() { urgentItem, nonUrgentItem, itemWithNextReplDateOnFirstReplDate, itemNotInShoppingList };

            return collection.AsQueryable();
        }


        public IQueryable<ReplenishmentItemDto> BuildDifferentDatesItemsDtosCollectionFiltered()
        {
            var urgentItem = BuildUrgentReplenishmentItemDto(new DateTime(2020, 10, 02));
            var itemWithNextReplDateOnFirstReplDate = BuildItemDtoWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));
            var nonUrgentItem = BuildNonUrgentReplenishmentItemDto(new DateTime(2020, 10, 06));

            var collection = new List<ReplenishmentItemDto>() { urgentItem, itemWithNextReplDateOnFirstReplDate, nonUrgentItem };

            return collection.AsQueryable();
        }

        public IQueryable<Item> BuildDifferentDatesItemsCollection()
        {
            var urgentItem = BuildUrgentItem(new DateTime(2020, 10, 02));
            var itemWithNextReplDateOnFirstReplDate = BuildItemWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));
            var nonUrgentItem = BuildNonUrgentItem(new DateTime(2020, 10, 06));
            var itemNotInShoppingList = BuildOutOfShoppingDateItem(new DateTime(2020, 10, 20));

            var collection = new List<Item>() { urgentItem, itemWithNextReplDateOnFirstReplDate, nonUrgentItem, itemNotInShoppingList };

            return collection.AsQueryable();
        }

        public IQueryable<Item> BuildDifferentDatesItemsCollectionFiltered()
        {
            var urgentItem = BuildUrgentItem(new DateTime(2020, 10, 02));
            var itemWithNextReplDateOnFirstReplDate = BuildItemWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));
            var nonUrgentItem = BuildNonUrgentItem(new DateTime(2020, 10, 06));

            var collection = new List<Item>() { urgentItem, itemWithNextReplDateOnFirstReplDate, nonUrgentItem };

            return collection.AsQueryable();
        }


        protected Item BuildOutOfShoppingDateItem(DateTime nextReplenishmentDate)
        {
            var item = new Item()
            {
                Id = 4,
                Name = "Oranges",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentPeriod = 10,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0",
            };

            return item;
        }

        protected ReplenishmentItemDto BuildOutOfShoppingListReplenishmentItemDto(DateTime nextReplenishmentDate)
        {
            var itemDto = new ReplenishmentItemDto()
            {
                Id = 4,
                Name = "Oranges",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01)
            };

            return itemDto;
        }


        protected Item BuildUrgentItem(DateTime nextReplenishmentDate)
        {
            var item = new Item()
            {
                Id = 1,
                Name = "Popcorn",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentPeriod = 4,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0",
            };

            return item;
        }

        protected ReplenishmentItemDto BuildUrgentReplenishmentItemDto(DateTime nextReplenishmentDate)
        {
            var itemDto = new ReplenishmentItemDto()
            {
                Id = 1,
                Name = "Popcorn",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01)
            };

            return itemDto;
        }

        protected PurchaseItemViewModel BuildUrgentReplenishmentItemViewModel(DateTime nextReplenishmentDate)
        {
            var itemViewModel = new PurchaseItemViewModel()
            {
                ItemId = 1,
                Name = "Popcorn",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01),
                Quantity = "3",
                ReplenishmentSignalClass = "itemNeedsReplenishment"
            };

            return itemViewModel;
        }

        protected Item BuildItemWithReplenishmentOnFirstReplDate(DateTime nextReplenishmentDate)
        {
            var firstItem = new Item()
            {
                Id = 2,
                Name = "Brownies",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentPeriod = 1,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0",
            };

            return firstItem;
        }

        protected ReplenishmentItemDto BuildItemDtoWithReplenishmentOnFirstReplDate(DateTime nextReplenishmentDate)
        {
            var itemDto = new ReplenishmentItemDto()
            {
                Id = 2,
                Name = "Brownies",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01)
            };

            return itemDto;
        }


        protected PurchaseItemViewModel BuildItemViewModelWithReplenishmentOnFirstReplDate(DateTime nextReplenishmentDate)
        {
            var itemViewModel = new PurchaseItemViewModel()
            {
                ItemId = 2,
                Name = "Brownies",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01),
                Quantity = "7",
                ReplenishmentSignalClass = string.Empty
            };

            return itemViewModel;
        }

        protected Item BuildNonUrgentItem(DateTime nextReplenishmentDate)
        {
            var firstItem = new Item()
            {
                Id = 3,
                Name = "Yoghurt",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentPeriod = 2,
                UserId = "ab70793b-cec8-4eba-99f3-cbad0b1649d0",
            };

            return firstItem;
        }

        protected ReplenishmentItemDto BuildNonUrgentReplenishmentItemDto(DateTime nextReplenishmentDate)
        {
            var itemDto = new ReplenishmentItemDto()
            {
                Id = 3,
                Name = "Yoghurt",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01)
            };

            return itemDto;
        }

        protected PurchaseItemViewModel BuildNonUrgentItemViewModel(DateTime nextReplenishmentDate)
        {
            var itemViewModel = new PurchaseItemViewModel()
            {
                ItemId = 3,
                Name = "Yoghurt",
                NextReplenishmentDate = nextReplenishmentDate,
                ReplenishmentDate = new DateTime(2020, 10, 01),
                Quantity = "3",
                ReplenishmentSignalClass = string.Empty
            };

            return itemViewModel;
        }
    }
}
