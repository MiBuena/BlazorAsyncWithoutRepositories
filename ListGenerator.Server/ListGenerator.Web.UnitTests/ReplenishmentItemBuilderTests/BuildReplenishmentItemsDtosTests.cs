using AutoMapper;
using FluentAssertions;
using ListGenerator.Data.Entities;
using ListGenerator.Server.Builders;
using ListGenerator.Server.Interfaces;
using ListGenerator.Shared.Dtos;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Web.UnitTests.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListGenerator.Web.UnitTests.ReplenishmentItemBuilderTests
{
    [TestFixture]
    public class BuildReplenishmentItemsDtosTests : BaseItemsTests
    {
        [SetUp]
        public virtual void Init()
        {
            DateTimeProviderMock = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            MapperMock = new Mock<IMapper>(MockBehavior.Strict);
            ReplenishmentItemBuilder = new ReplenishmentItemBuilder(DateTimeProviderMock.Object, MapperMock.Object);
        }

        protected Mock<IDateTimeProvider> DateTimeProviderMock { get; private set; }
        protected Mock<IMapper> MapperMock { get; private set; }
        protected IReplenishmentItemBuilder ReplenishmentItemBuilder { get; private set; }


        [Test]
        public void Should_ReturnCollectionWithThreeDtos_When_InputCollectionHasThreeItems()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            dtos.Count().Should().Be(3);
        }

        [Test]
        public void Should_ReturnCollection_WithUrgentDto_WithCorrectMappedProperties_When_InputCollectionHasAnUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.First().Id.Should().Be(1),
                () => dtos.First().Name.Should().Be("Popcorn"),
                () => dtos.First().NextReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 02))
                );
        }


        [Test]
        public void Should_ReturnCollection_WithUrgentDto_WithCorrectQuantity_When_InputCollectionHasAnUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.First().Quantity.Should().Be(3)
                );
        }

        [Test]
        public void Should_ReturnCollection_WithUrgentDto_WithCorrectReplenishmentDate_When_InputCollectionHasAnUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.First().ReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 01))
                );
        }

        [Test]
        public void Should_ReturnCollection_WithUrgentDto_WithUrgencyPropertySetToTrue_When_InputCollectionHasAnUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.First().ItemNeedsReplenishmentUrgently.Should().BeTrue()
                );
        }

        [Test]
        public void Should_ReturnCollection_WithDtoWithNextReplDateOnFirstReplDate_WithCorrectMappedProperties_When_InputCollectionHasAnItemWithNextReplDateOnFirstReplDate()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(1).First().Id.Should().Be(2),
                () => dtos.Skip(1).First().Name.Should().Be("Brownies"),
                () => dtos.Skip(1).First().NextReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 04))
                );
        }


        [Test]
        public void Should_ReturnCollection_WithDtoWithNextReplDateOnFirstReplDate_WithCorrectQuantity_When_InputCollectionHasAnItemWithNextReplDateOnFirstReplDate()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(1).First().Quantity.Should().Be(7)
                );
        }

        [Test]
        public void Should_ReturnCollection_WithDtoWithNextReplDateOnFirstReplDate_WithCorrectReplenishmentDate_When_InputCollectionHasAnItemWithNextReplDateOnFirstReplDate()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(1).First().ReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 01))
                );
        }

        [Test]
        public void Should_ReturnCollection_WithDtoWithNextReplDateOnFirstReplDate_WithUrgencyPropertySetToTrue_When_InputCollectionHasAnItemWithNextReplDateOnFirstReplDate()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(1).First().ItemNeedsReplenishmentUrgently.Should().BeFalse()
                );
        }


        [Test]
        public void Should_ReturnCollection_WithNonUrgentDto_WithCorrectMappedProperties_When_InputCollectionHasANonUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(2).First().Id.Should().Be(3),
                () => dtos.Skip(2).First().Name.Should().Be("Yoghurt"),
                () => dtos.Skip(2).First().NextReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 06))
                );
        }

        [Test]
        public void Should_ReturnCollection_WithNonUrgentDto_WithCorrectQuantity_When_InputCollectionHasANonUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(2).First().Quantity.Should().Be(3)
                );
        }

        [Test]
        public void Should_ReturnCollection_WithNonUrgentDto_WithCorrectReplenishmentDate_When_InputCollectionHasANonUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(2).First().ReplenishmentDate.Should().BeSameDateAs(new DateTime(2020, 10, 01))
                );
        }

        [Test]
        public void Should_ReturnCollection_WithNonUrgentDto_WithUrgencyPropertySetToTrue_When_InputCollectionHasANonUrgentItem()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);


            //Assert
            AssertHelper.AssertAll(
                () => dtos.Skip(2).First().ItemNeedsReplenishmentUrgently.Should().BeFalse()
                );
        }

        [Test]
        public void Should_ThrowException_When_InputCollectionIsNull()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);


            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, null));
        }

        [Test]
        public void Should_ThrowException_When_FirstReplenishmentDateIsAfterSecondReplenishmentDate()
        {
            //Arrange
            var items = InitializeWithCollection();

            var firstReplenishmentDate = new DateTime(2020, 10, 11); 
            var secondReplenishmentDate = new DateTime(2020, 10, 04);


            //Act
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items));

            Assert.That(ex.Message, Is.EqualTo("firstReplenishmentDate : 11.10.2020 should be before secondReplenishmentDate : 04.10.2020"));
        }


        [Test]
        public void Should_ReturnEmptyCollection_When_FirstReplenishmentDateIsAfterSecondReplenishmentDate()
        {
            //Arrange
            var items = new List<Item>();
            ItemsTestHelper.InitializeDateTimeProviderMock(DateTimeProviderMock);

            var firstReplenishmentDate = new DateTime(2020, 10, 04);
            var secondReplenishmentDate = new DateTime(2020, 10, 11);

            //Act
            var dtos = ReplenishmentItemBuilder.BuildReplenishmentItemsDtos(firstReplenishmentDate, secondReplenishmentDate, items);

            //Assert
            dtos.Count().Should().Be(0);
        }

        private IEnumerable<Item> InitializeWithCollection()
        {
            ItemsTestHelper.InitializeDateTimeProviderMock(DateTimeProviderMock);

            var urgentItem = BuildUrgentItem(new DateTime(2020, 10, 02));
            var urgentItemDto = BuildUrgentReplenishmentItemDto(new DateTime(2020, 10, 02));

            var itemOnFirstReplDate = BuildItemWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));
            var itemDtoOnFirstReplDate = BuildItemDtoWithReplenishmentOnFirstReplDate(new DateTime(2020, 10, 04));

            var nonUrgentItem = BuildNonUrgentItem(new DateTime(2020, 10, 06));
            var nonUrgentItemDto = BuildNonUrgentReplenishmentItemDto(new DateTime(2020, 10, 06));

            MapperMock.Setup(c => c.Map<Item, ReplenishmentItemDto>(urgentItem))
                .Returns(urgentItemDto);

            MapperMock.Setup(c => c.Map<Item, ReplenishmentItemDto>(itemOnFirstReplDate))
                .Returns(itemDtoOnFirstReplDate);

            MapperMock.Setup(c => c.Map<Item, ReplenishmentItemDto>(nonUrgentItem))
                .Returns(nonUrgentItemDto);

            var collection = new List<Item>() { urgentItem, itemOnFirstReplDate, nonUrgentItem };

            return collection;
        }
    }
}
