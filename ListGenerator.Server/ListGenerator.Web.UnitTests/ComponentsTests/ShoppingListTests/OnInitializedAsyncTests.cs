using AutoMapper;
using Bunit;
using ListGenerator.Client.Builders;
using ListGenerator.Client.Pages;
using ListGenerator.Client.Services;
using ListGenerator.Client.ViewModels;
using ListGenerator.Shared.Dtos;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ListGenerator.Web.UnitTests.ComponentsTests.ShoppingListTests
{
    [TestFixture]
    public class OnInitializedAsyncTests : BUnitTestContext
    {
        private Mock<IReplenishmentService> _mockReplenishmentService;

        private Mock<IDateTimeProvider> _mockDateTimeProvider;

        private Mock<NavigationManager> _mockNavigationManager;

        private Mock<IItemBuilder> _mockItemBuilder;

        private Mock<IReplenishmentBuilder> _mockReplenishmentBuilder;

        private Mock<IMapper> _mockMapper;



        [SetUp]
        public void Init()
        {
            _mockReplenishmentService = new Mock<IReplenishmentService>();
            _mockDateTimeProvider = new Mock<IDateTimeProvider>();
            _mockNavigationManager = new Mock<NavigationManager>();
            _mockItemBuilder = new Mock<IItemBuilder>();
            _mockReplenishmentBuilder = new Mock<IReplenishmentBuilder>();
            _mockMapper = new Mock<IMapper>();

            Services.AddSingleton(_mockReplenishmentService.Object);
            Services.AddSingleton(_mockDateTimeProvider.Object);
            Services.AddSingleton(_mockNavigationManager.Object);
            Services.AddSingleton(_mockItemBuilder.Object);
            Services.AddSingleton(_mockReplenishmentBuilder.Object);
            Services.AddSingleton(_mockMapper.Object);
        }

        [Test]
        public void Should_DisplayNextShoppingDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var firstShoppingDateValue = cut.Find(".first-shopping-date input").GetAttribute("value");

            Assert.AreEqual("2020-10-04", firstShoppingDateValue);
        }

        [Test]
        public void Should_DisplayNextShoppingDateInputWithMaxValueAtTheSecondShoppingDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var firstShoppingDateMaxValue = cut.Find(".first-shopping-date input").GetAttribute("max");

            Assert.AreEqual("2020-10-11", firstShoppingDateMaxValue);
        }


        [Test]
        public void Should_DisplayDropdownWithDaysOfTheWeek_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var renderedMarkup = cut.Find(".normal-shopping-day-select");

            renderedMarkup.MarkupMatches(
                "<select class=\"app-input-control normal-shopping-day-select\"><!--!-->" + Environment.NewLine +
"                <option value=\"Sunday\">Sunday</option><!--!-->" + Environment.NewLine +
"                <option value=\"Monday\">Monday</option><!--!-->" + Environment.NewLine +
"                <option value=\"Tuesday\">Tuesday</option><!--!-->" + Environment.NewLine +
"                <option value=\"Wednesday\">Wednesday</option><!--!-->" + Environment.NewLine +
"                <option value=\"Thursday\">Thursday</option><!--!-->" + Environment.NewLine +
"                <option value=\"Friday\">Friday</option><!--!-->" + Environment.NewLine +
"                <option value=\"Saturday\">Saturday</option><!--!-->" + Environment.NewLine +
"        </select>");
        }

        [Test]
        public void Should_DisplayNextShoppingDateAsInputWithTypeDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var firstShoppingDateInputType = cut.Find(".first-shopping-date input").GetAttribute("type");

            Assert.AreEqual("date", firstShoppingDateInputType);
        }

        [Test]
        public void Should_DisplaySecondShoppingDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var secondShoppingDateValue = cut.Find(".second-shopping-date input").GetAttribute("value");

            Assert.AreEqual("2020-10-11", secondShoppingDateValue);
        }

        [Test]
        public void Should_DisplaySecondShoppingDateInputWithMinValueAtTheFirstShoppingDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var secondShoppingDateMin = cut.Find(".second-shopping-date input").GetAttribute("min");

            Assert.AreEqual("2020-10-04", secondShoppingDateMin);
        }

        [Test]
        public void Should_DisplaySecondShoppingDateAsInputWithTypeDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var secondShoppingDateType = cut.Find(".second-shopping-date input").GetAttribute("type");

            Assert.AreEqual("date", secondShoppingDateType);
        }

        [Test]
        public void Should_DisplayShoppingListDate_When_ShoppingListInitialized()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var shoppingListDate = cut.Find(".shopping-list-date").TextContent;

            shoppingListDate.MarkupMatches("4.10.2020");
        }

        [Test]
        public void Should_DisplayThreeShoppingItemsInTheShoppingList_When_ThreeItemsNeedReplenishment()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var shoppingListItemsCount = cut.FindAll(".items-shopping-list-table tbody tr").Count;

            Assert.AreEqual(3, shoppingListItemsCount);
        }

        [Test]
        public void Should_DisplayFirstShoppingItemDataCorrectly()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var firstItemName = cut.FindAll(".replenishment-item-name").First().TextContent;
            var firstItemNextReplenishmentDate = cut.FindAll(".replenishment-item-next-replenishment-date").First().TextContent;
            var firstItemQuantityToBuy = cut.FindAll(".replenishment-item-quantity-to-buy option").First(x => x.HasAttribute("selected")).TextContent;
            var firstItemShoppingDate = cut.FindAll(".replenishment-item-shopping-date input").First().GetAttribute("value");

            AssertHelper.AssertAll(
                () => firstItemName.MarkupMatches("Popcorn"),
                () => firstItemNextReplenishmentDate.MarkupMatches("2.10.2020"),
                () => firstItemQuantityToBuy.MarkupMatches("3"),
                () => firstItemShoppingDate.MarkupMatches("2020-10-01")
            );
        }


        [Test]
        public void Should_DisplayAllShoppingItemsShoppingDatesWithCorrectAttributes()
        {
            //Arrange
            InitializeShoppingList();

            //Act
            var cut = RenderComponent<ShoppingList>();

            // Assert
            var allShoppingDateInputs = cut.FindAll(".replenishment-item-shopping-date input");

            foreach (var input in allShoppingDateInputs)
            {
                var max = input.GetAttribute("max");
                max.MarkupMatches("2020-10-01");

                var type = input.GetAttribute("type");
                type.MarkupMatches("date");
            }
        }

        private void InitializeShoppingList()
        {
            var mockDate = new DateTime(2020, 10, 01);
            _mockDateTimeProvider.Setup(x => x.GetDateTimeNowDate()).Returns(mockDate);

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);

            var urgentItem = BuildUrgentReplenishmentItemDto(new DateTime(2020, 10, 02));
            var nonUrgentItem = BuildNonUrgentReplenishmentItemDto(new DateTime(2020, 10, 06));
            var itemWithNextReplDateOnFirstReplDate = BuildItemDtoWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));

            var replenishmentItemsCollection = new List<ReplenishmentItemDto>() { urgentItem, nonUrgentItem, itemWithNextReplDateOnFirstReplDate };


            var response = new Response<IEnumerable<ReplenishmentItemDto>>()
            {
                IsSuccess = true,
                Data = replenishmentItemsCollection
            };

            var urgentItemViewModel = BuildUrgentReplenishmentItemViewModel(new DateTime(2020, 10, 02));
            var nonUrgentItemViewModel = BuildNonUrgentItemViewModel(new DateTime(2020, 10, 06));
            var itemViewModelWithReplDateOnFirstReplDate = BuildItemViewModelWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));

            _mockReplenishmentService.Setup(c => c.GetShoppingListItems(firstReplenishmentDate, secondReplenishmentDate))
            .ReturnsAsync(response);


            _mockMapper.Setup(c => c.Map<ReplenishmentItemDto, PurchaseItemViewModel>(It.Is<ReplenishmentItemDto>(x=>x.Id == urgentItem.Id)))
                .Returns(urgentItemViewModel);

            _mockMapper.Setup(c => c.Map<ReplenishmentItemDto, PurchaseItemViewModel>(It.Is<ReplenishmentItemDto>(x => x.Id == itemWithNextReplDateOnFirstReplDate.Id)))
                .Returns(itemViewModelWithReplDateOnFirstReplDate);

            _mockMapper.Setup(c => c.Map<ReplenishmentItemDto, PurchaseItemViewModel>(It.Is<ReplenishmentItemDto>(x => x.Id == nonUrgentItem.Id)))
                .Returns(nonUrgentItemViewModel);
        }
    }
}
