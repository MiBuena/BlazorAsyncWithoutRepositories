using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using ListGenerator.Client.ViewModels;
using ListGenerator.Data.Entities;
using ListGenerator.Data.Interfaces;
using ListGenerator.Server.Interfaces;
using ListGenerator.Server.Services;
using ListGenerator.Shared.Dtos;
using ListGenerator.Web.UnitTests.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace ListGenerator.Web.UnitTests.ItemsDataServiceTests
{
    [TestFixture]
    public class GetItemsNamesTests : BaseItemsDataServiceTests
    {
        [SetUp]
        protected override void Init()
        {
            base.Init();
        }

        [Test]
        public void Should_ReturnSuccessResponseWithOneEntry_When_OneItemNameOfThisUserContainsSearchWord()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildFirstItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemNameDto = BuildFirstItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { filteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("d", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Count().Should().Be(1),
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull()
                );
        }

        [Test]
        public void Should_ReturnResponseWithCorrectItemName_When_OneItemNameOfThisUserContainSearchWord()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildFirstItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemNameDto = BuildFirstItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { filteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
                .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("d", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            result.Data.First().Name.Should().Be("Bread");
        }

        [Test]
        public void Should_ReturnSuccessResponseWithTwoEntries_When_TwoItemsNamesOfThisUserContainSearchWord()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var firstFilteredItem = BuildFirstItem();
            var secondFilteredItem = BuildThirdItem();
            var filteredItems = new List<Item>() { firstFilteredItem, secondFilteredItem };

            var firstFilteredItemNameDto = BuildFirstItemNameDto();
            var secondFilteredItemNameDto = BuildThirdItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { firstFilteredItemNameDto, secondFilteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("B", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Count().Should().Be(2),
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull()
                );
        }


        [Test]
        public void Should_ReturnResponseWithCorrectItemsNames_When_TwoItemsNamesOfThisUserContainSearchWord()
        {
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var firstFilteredItem = BuildFirstItem();
            var secondFilteredItem = BuildThirdItem();
            var filteredItems = new List<Item>() { firstFilteredItem, secondFilteredItem };

            var firstFilteredItemNameDto = BuildFirstItemNameDto();
            var secondFilteredItemNameDto = BuildThirdItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { firstFilteredItemNameDto, secondFilteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("B", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
            () => result.Data.First().Name.Should().Be("Bread"),
            () => result.Data.Skip(1).First().Name.Should().Be("Biscuits"));
        }

        [Test]
        public void Should_ReturnSuccessResponseWithOneEntry_When_OneItemNameOfThisUserContainsSearchWord_SearchShouldBeCaseInsensitive()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildFirstItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemNameDto = BuildFirstItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { filteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("R", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Count().Should().Be(1),
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull()
            );
        }

        [Test]
        public void Should_ReturnResponseWithCorrectItemName_When_OneItemNameOfThisUserContainSearchWord_SearchShouldBeCaseInsensitive()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildFirstItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemNameDto = BuildFirstItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { filteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("Re", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            result.Data.First().Name.Should().Be("Bread");
        }

        [Test]
        public void Should_ReturnSuccessResponseWithNoEntries_When_ThereAreNoItemsInRepository()
        {
            //Arrange
            InitializeMocksWithEmptyCollection();

            //Act
            var result = ItemsDataService.GetItemsNames("B", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Count().Should().Be(0),
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull()
                );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_AnExceptionOccursInRepositoryAllMethod()
        {
            //Arrange
            var allItems = new List<Item>().AsQueryable();
            ItemsRepositoryMock.Setup(x => x.All()).Throws(new Exception());

            var filteredItems = new List<Item>();
            var filteredItemNameDtos = new List<ItemNameDto>();

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames("B", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting items names."),
                () => result.Data.Should().BeNull()
            );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_AnExceptionOccursInProjectToMethod()
        {
            //Arrange
            var allItems = new List<Item>().AsQueryable();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItems = new List<Item>();

            MapperMock.Setup(c => c.ProjectTo(
                It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                null,
                It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
                .Throws(new Exception());

            //Act
            var result = ItemsDataService.GetItemsNames("B", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting items names."),
                () => result.Data.Should().BeNull()
            );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_SearchWordIsNull()
        {
            //Arrange
            InitializeMocksWithEmptyCollection();


            //Act
            var result = ItemsDataService.GetItemsNames(null, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting items names."),
                () => result.Data.Should().BeNull()
            );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_UserIdIsNull()
        {
            //Arrange
            InitializeMocksWithEmptyCollection();

            //Act
            var result = ItemsDataService.GetItemsNames("B", null);

            //Assert
            AssertHelper.AssertAll(
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting items names."),
                () => result.Data.Should().BeNull()
            );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_UserIdIsEmpty()
        {
            //Arrange
            InitializeMocksWithEmptyCollection();

            //Act
            var result = ItemsDataService.GetItemsNames("B", string.Empty);

            //Assert
            AssertHelper.AssertAll(
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting items names."),
                () => result.Data.Should().BeNull()
            );
        }


        [Test]
        public void Should_ReturnSuccessResponseWithNoEntries_When_UserIdDoesNotExist()
        {
            //Arrange
            InitializeMocksWithEmptyCollection();


            //Act
            var result = ItemsDataService.GetItemsNames("Re", "1111");


            //Assert
            AssertHelper.AssertAll(
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull(),
                () => result.Data.Count().Should().Be(0)
            );
        }

        [Test]
        public void Should_ReturnSuccessResponseWithAllItemsNamesOfThisUser_When_SearchWordIsEmptyString()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var firstFilteredItem = BuildFirstItem();
            var secondFilteredItem = BuildSecondItem();
            var thirdFilteredItem = BuildThirdItem();
            var filteredItems = new List<Item>() { firstFilteredItem, secondFilteredItem, thirdFilteredItem };

            var firstFilteredItemNameDto = BuildFirstItemNameDto();
            var secondFilteredItemNameDto = BuildSecondItemNameDto();
            var thirdFilteredItemNameDto = BuildThirdItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { firstFilteredItemNameDto, secondFilteredItemNameDto, thirdFilteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames(string.Empty, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Count().Should().Be(3),
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull());
        }

        [Test]
        public void Should_ReturnResponseWithCorrectItemsNamesOfAllItemsOfThisUser_When_SearchWordIsEmptyString()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var firstFilteredItem = BuildFirstItem();
            var secondFilteredItem = BuildSecondItem();
            var thirdFilteredItem = BuildThirdItem();
            var filteredItems = new List<Item>() { firstFilteredItem, secondFilteredItem, thirdFilteredItem };

            var firstFilteredItemNameDto = BuildFirstItemNameDto();
            var secondFilteredItemNameDto = BuildSecondItemNameDto();
            var thirdFilteredItemNameDto = BuildThirdItemNameDto();
            var filteredItemNameDtos = new List<ItemNameDto>() { firstFilteredItemNameDto, secondFilteredItemNameDto, thirdFilteredItemNameDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemNameDtos.AsQueryable());

            //Act
            var result = ItemsDataService.GetItemsNames(string.Empty, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

            //Assert
            AssertHelper.AssertAll(
                () => result.Data.First().Name.Should().Be("Bread"),
                () => result.Data.Skip(1).First().Name.Should().Be("Cheese"),
                () => result.Data.Skip(2).First().Name.Should().Be("Biscuits")
            );
        }
    }
}
