using Bunit;
using ListGenerator.Client.Pages;
using ListGenerator.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Web.UnitTests.ComponentsTests.SpinnerTests
{
    [TestFixture]
    public class ShowSpinnerTests : BaseSpinnerTests
    {
        [Test]
        public void Should_HaveEmptyMarkUp_When_SpinnerIsNotShown()
        {
            //Act
            var cut = RenderComponent<Spinner>();

            // Assert
            cut.MarkupMatches(string.Empty);
        }

        [Test]
        public void Should_HaveDivWithSpinnerContainerClassWithElements_When_SpinnerIsShown()
        {
            //Act
            var cut = RenderComponent<Spinner>();
            cut.InvokeAsync(() => cut.Instance.ShowSpinner());


            // Assert
            var renderedMarkup = cut.Find(".spinner-container");
            Assert.IsTrue(renderedMarkup.ChildElementCount > 0);
        }
    }
}
