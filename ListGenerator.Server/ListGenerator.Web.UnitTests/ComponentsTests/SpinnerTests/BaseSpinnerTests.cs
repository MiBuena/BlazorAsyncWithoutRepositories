using ListGenerator.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Web.UnitTests.ComponentsTests.SpinnerTests
{
    public abstract class BaseSpinnerTests : BUnitTestContext
    {
        protected Mock<ISpinnerService> _mockSpinnerService;

        [SetUp]
        public void Init()
        {
            _mockSpinnerService = new Mock<ISpinnerService>();
            Services.AddSingleton(_mockSpinnerService.Object);
        }
    }
}
