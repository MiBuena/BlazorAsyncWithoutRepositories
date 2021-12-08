using Bunit;
using ListGenerator.Client.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ListGenerator.Web.UnitTests.ComponentsTests.SpinnerTests
{
    [TestFixture]
    public class OnInitializedTests : BaseSpinnerTests
    {
        public void Should_AddActionsToSpinnerService_When_SpinnerIsInitialized()
        {
            var cut = RenderComponent<Spinner>();

            //_mockSpinnerService.Verify(c => c., Times.Once());
        }
    }
}
