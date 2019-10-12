using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using BglGithubSite.Models;

namespace BglGithubSite.Tests.Services
{
    public class GithubUserServiceTest : ServiceTestsBase
    {
        [Fact]
        public async Task GetGithubUserAsync()
        {
            var query = new Query
            {
                Username = "test-user-name"
            };

            var actual = await service.GetGithubUser(query);

            actual.Should().NotBeNull();
            actual.Name.Should().Be("Test Name");
        }
    }
}
