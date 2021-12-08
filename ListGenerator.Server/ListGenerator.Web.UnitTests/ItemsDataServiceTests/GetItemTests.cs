using AutoMapper;
using FluentAssertions;
using ListGenerator.Data.Entities;
using ListGenerator.Data.Interfaces;
using ListGenerator.Server.Interfaces;
using ListGenerator.Server.Services;
using ListGenerator.Shared.Dtos;
using ListGenerator.Web.UnitTests.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ListGenerator.Web.UnitTests.ItemsDataServiceTests
{
    [TestFixture]
    public class GetItemTests : BaseItemsDataServiceTests
    {
        [SetUp]
        protected override void Init()
        {
            base.Init();
        }

        [Test]
        public void Should_ReturnSuccessResponseWithItem_When_CurrentUserHasItemWithThisId()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildSecondItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemDto = BuildSecondItemDto();
            var filteredItemDtos = new List<ItemDto>() { filteredItemDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemDtos.AsQueryable());


            //Act
            var result = ItemsDataService.GetItem(2, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Should().NotBeNull(),
                () => result.IsSuccess.Should().BeTrue(),
                () => result.ErrorMessage.Should().BeNull()
                );
        }


        [Test]
        public void Should_ReturnResponseWithCorrectItem_When_CurrentUserHasItemWithThisId()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildSecondItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemDto = BuildSecondItemDto();
            var filteredItemDtos = new List<ItemDto>() { filteredItemDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemDtos.AsQueryable());


            //Act
            var result = ItemsDataService.GetItem(2, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Id.Should().Be(2),
                () => result.Data.Name.Should().Be("Cheese"),
                () => result.Data.NextReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 08)),
                () => result.Data.ReplenishmentPeriod.Should().Be(2)
                );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_CurrentUserDoesNotHaveItemWithThisId()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItems = new List<Item>();
            var filteredItemDtos = new List<ItemDto>();

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemDtos.AsQueryable());


            //Act
            var result = ItemsDataService.GetItem(2, "925912b0-c59c-4e1b-971a-06e8abab7848");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Should().BeNull(),
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("Current user does not have item with id 2")
                );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_ItemWithThisIdDoesNotExist()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItems = new List<Item>();
            var filteredItemDtos = new List<ItemDto>();

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemDtos.AsQueryable());


            //Act
            var result = ItemsDataService.GetItem(20, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Should().BeNull(),
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("Current user does not have item with id 20")
                );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_AnErrorOccursInRepositoryAllMethod()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Throws(new Exception());

            var filteredItem = BuildSecondItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemDto = BuildSecondItemDto();
            var filteredItemDtos = new List<ItemDto>() { filteredItemDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemDtos.AsQueryable());


            //Act
            var result = ItemsDataService.GetItem(2, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Should().BeNull(),
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting item")
                );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_AnErrorOccursInProjectToMethod()
        {
            //Arrange
            var allItems = BuildItemsCollection();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItem = BuildSecondItem();
            var filteredItems = new List<Item>() { filteredItem };

            var filteredItemDto = BuildSecondItemDto();
            var filteredItemDtos = new List<ItemDto>() { filteredItemDto };

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
                .Throws(new Exception());


            //Act
            var result = ItemsDataService.GetItem(2, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Should().BeNull(),
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("An error occured while getting item")
                );
        }

        [Test]
        public void Should_ReturnErrorResponse_When_NoItemsExist()
        {
            //Arrange
            var allItems = new List<Item>().AsQueryable();
            ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

            var filteredItems = new List<Item>();
            var filteredItemDtos = new List<ItemDto>();

            MapperMock
                .Setup(c => c.ProjectTo(
                    It.Is<IQueryable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x)),
                    null,
                    It.Is<Expression<Func<ItemDto, object>>[]>(x => x.Length == 0)))
             .Returns(filteredItemDtos.AsQueryable());


            //Act
            var result = ItemsDataService.GetItem(2, "ab70793b-cec8-4eba-99f3-cbad0b1649d0");


            //Assert
            AssertHelper.AssertAll(
                () => result.Data.Should().BeNull(),
                () => result.IsSuccess.Should().BeFalse(),
                () => result.ErrorMessage.Should().Be("Current user does not have item with id 2")
                );
        }
    }
}
