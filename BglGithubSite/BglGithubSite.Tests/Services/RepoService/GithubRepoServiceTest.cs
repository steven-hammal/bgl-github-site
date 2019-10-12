using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using BglGithubSite.Models;

namespace BglGithubSite.Tests.Services.RepoService
{
    public class GithubRepoServiceTest: RepoServiceTestsBase
    {
        [Fact]
        public async Task GetGithubReposAsync()
        {
            var repo_url = "https://test/test-user/repos";
            var expectedRepo = new GithubRepo
            {
                Name = "Test Repo",
                Html_Url = "https://test/test_repo/repo",
                Stargazers_Count = 1
            };

            var actual = await service.GetGithubRepos(repo_url);

            actual.Should().NotBeNull();
            actual.FirstOrDefault().Should().BeEquivalentTo(expectedRepo);
        }
    }
}
