using AutoMapper;
using ListGenerator.Data.Entities;
using ListGenerator.Data.Interfaces;
using ListGenerator.Server.Interfaces;
using ListGenerator.Server.Services;
using ListGenerator.Shared.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Web.UnitTests.ReplenishmentDataServiceTests
{
    public class BaseReplenishmentDataServiceTests : BaseItemsTests
    {
        [SetUp]
        protected virtual void Init()
        {
            ItemsRepositoryMock = new Mock<IRepository<Item>>(MockBehavior.Strict);
            PurchaseRepositoryMock = new Mock<IRepository<Purchase>>(MockBehavior.Strict);
            MapperMock = new Mock<IMapper>(MockBehavior.Strict);
            ReplenishmentItemBuilderMock = new Mock<IReplenishmentItemBuilder>(MockBehavior.Strict);
            ReplenishmentDataService = new ReplenishmentDataService(ItemsRepositoryMock.Object, MapperMock.Object, PurchaseRepositoryMock.Object, ReplenishmentItemBuilderMock.Object);
        }

        protected Mock<IRepository<Item>> ItemsRepositoryMock { get; private set; }
        protected Mock<IRepository<Purchase>> PurchaseRepositoryMock { get; private set; }
        protected Mock<IMapper> MapperMock { get; private set; }
        protected Mock<IReplenishmentItemBuilder> ReplenishmentItemBuilderMock { get; private set; }
        protected IReplenishmentDataService ReplenishmentDataService { get; private set; }
    }
}
