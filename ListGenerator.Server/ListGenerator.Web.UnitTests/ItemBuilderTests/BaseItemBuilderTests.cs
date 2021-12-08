using AutoMapper;
using ListGenerator.Client.Builders;
using ListGenerator.Shared.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Web.UnitTests.ItemBuilderTests
{
    public class BaseItemBuilderTests
    {
        [SetUp]
        public virtual void Init()
        {
            DateTimeProviderMock = new Mock<IDateTimeProvider>(MockBehavior.Strict);
            MapperMock = new Mock<IMapper>(MockBehavior.Strict);
            ItemBuilder = new ItemBuilder(DateTimeProviderMock.Object, MapperMock.Object);
        }

        protected Mock<IDateTimeProvider> DateTimeProviderMock { get; private set; }
        protected Mock<IMapper> MapperMock { get; private set; }
        protected IItemBuilder ItemBuilder { get; private set; }
    }
}
