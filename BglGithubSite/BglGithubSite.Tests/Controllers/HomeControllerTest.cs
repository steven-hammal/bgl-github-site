using System.Web.Mvc;
using BglGithubSite.Controllers;
using Xunit;
using FluentAssertions;

namespace BglGithubSite.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            string message = result.ViewBag.Message;
            message.Should().Be("Your application description page.");
        }

        [Fact]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }
    }
}
