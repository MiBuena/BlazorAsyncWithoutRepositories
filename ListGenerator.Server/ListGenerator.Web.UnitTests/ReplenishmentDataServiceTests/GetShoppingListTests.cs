using FluentAssertions;
using FluentAssertions.Common;
using ListGenerator.Data.Entities;
using ListGenerator.Web.UnitTests.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListGenerator.Web.UnitTests.ReplenishmentDataServiceTests
{
    public class GetShoppingListTests : BaseReplenishmentDataServiceTests
    {
        [SetUp]
        protected override void Init()
        {
            base.Init();
        }

        //[Test]
        //public void Should_ReturnSuccessResponse_When_ValidInputparameters()
        //{
        //    //Arrange
        //    var allItems = BuildDifferentDatesItemsCollection();
        //    ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

        //    var filteredItems = BuildDifferentDatesItemsCollectionFiltered();
        //    var filteredDtos = BuildDifferentDatesItemsDtosCollectionFiltered();

        //    var allDtos = BuildDifferentDatesItemsDtosCollection();
        //    ReplenishmentItemBuilderMock
        //        .Setup(x => x.BuildReplenishmentItemsDtos(
        //            It.Is<DateTime>(x => x.IsSameOrEqualTo(new DateTime(2020, 10, 4))),
        //            It.Is<DateTime>(x => x.IsSameOrEqualTo(new DateTime(2020, 10, 11))),
        //            It.Is<IEnumerable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x))))
        //        .Returns(filteredDtos);

        //    //Act
        //    var response = ReplenishmentDataService.GetShoppingList("04-10-2020", "11-10-2020", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

        //    //Assert
        //    AssertHelper.AssertAll(
        //        () => response.IsSuccess.Should().BeTrue(),
        //        () => response.ErrorMessage.Should().BeNull()
        //        );
        //}


        //[Test]
        //public void Should_ReturnResponseWithThreeItems_When_ThreeItemsWithinShoppingListRange()
        //{
        //    //Arrange
        //    var allItems = BuildDifferentDatesItemsCollection();
        //    ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

        //    var filteredItems = BuildDifferentDatesItemsCollectionFiltered();
        //    var filteredDtos = BuildDifferentDatesItemsDtosCollectionFiltered();

        //    var allDtos = BuildDifferentDatesItemsDtosCollection();
        //    ReplenishmentItemBuilderMock
        //        .Setup(x => x.BuildReplenishmentItemsDtos(
        //            It.Is<DateTime>(x => x.IsSameOrEqualTo(new DateTime(2020, 10, 4))),
        //            It.Is<DateTime>(x => x.IsSameOrEqualTo(new DateTime(2020, 10, 11))),
        //            It.Is<IEnumerable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x))))
        //        .Returns(filteredDtos);

        //    //Act
        //    var response = ReplenishmentDataService.GetShoppingList("04-10-2020", "11-10-2020", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

        //    //Assert
        //    response.Data.Count().Should().Be(3);
        //}


        //[Test]
        //public void Should_ReturnResponseWithCorrectFirstItem_When_ThreeItemsWithinShoppingListRange()
        //{
        //    //Arrange
        //    var allItems = BuildDifferentDatesItemsCollection();
        //    ItemsRepositoryMock.Setup(x => x.All()).Returns(allItems);

        //    var filteredItems = BuildDifferentDatesItemsCollectionFiltered();
        //    var filteredDtos = BuildDifferentDatesItemsDtosCollectionFiltered();

        //    var allDtos = BuildDifferentDatesItemsDtosCollection();
        //    ReplenishmentItemBuilderMock
        //        .Setup(x => x.BuildReplenishmentItemsDtos(
        //            It.Is<DateTime>(x => x.IsSameOrEqualTo(new DateTime(2020, 10, 4))),
        //            It.Is<DateTime>(x => x.IsSameOrEqualTo(new DateTime(2020, 10, 11))),
        //            It.Is<IEnumerable<Item>>(x => ItemsTestHelper.HaveTheSameElements(filteredItems, x))))
        //        .Returns(filteredDtos);

        //    //Act
        //    var response = ReplenishmentDataService.GetShoppingList("04-10-2020", "11-10-2020", "ab70793b-cec8-4eba-99f3-cbad0b1649d0");

        //    //Assert
        //    AssertHelper.AssertAll(
        //        () => response.Data.First().Id.Should().Be(1),
        //        () => response.Data.First().Name.Should().Be("Popcorn"),
        //        () => response.Data.First().NextReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 02)),
        //        () => response.Data.First().Quantity.Should().Be(3),
        //        () => response.Data.First().ReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 01)),
        //        () => response.Data.First().ItemNeedsReplenishmentUrgently.Should().BeTrue()
        //        );
        //}

    }
}
