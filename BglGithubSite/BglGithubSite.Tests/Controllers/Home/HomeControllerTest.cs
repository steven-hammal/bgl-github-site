using System.Web.Mvc;
using Xunit;
using FluentAssertions;
using BglGithubSite.Models;
using BglGithubSite.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BglGithubSite.Tests.Controllers.Home
{
    public class HomeControllerTest: HomeControllerTestBase
    {
        [Fact]
        public void Index()
        {
            // Arrange
            // All setup takes place in the base class

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Search_ReturnsAViewResult_WithAGithubUserViewModel()
        {
            // Assemble
            var query = new Query
            {
                Username = "test-user"
            };

            // Act
            var result = await controller.Search(query);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GithubUserViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal("Test User", model.Name);
        }
    }
}
