using System;
using System.Collections.Generic;
using BglGithubSite.Controllers;
using Moq;
using BglGithubSite.Services.Contracts;
using BglGithubSite.Models;

namespace BglGithubSite.Tests.Controllers.Home
{
    public abstract class HomeControllerTestBase: IDisposable
    {
        public HomeController controller;
        bool disposed = false;

        protected HomeControllerTestBase()
        {
            var mockGithubUserService = new Mock<IGithubUserService>();
            var mockGithubRepoService = new Mock<IGithubRepoService>();

            mockGithubUserService.Setup(service => service.GetGithubUser(It.IsAny<Query>()))
                                                    .ReturnsAsync(GetTestGithubUser());
            mockGithubRepoService.Setup(service => service.GetGithubRepos(It.IsAny<string>()))
                                                    .ReturnsAsync(GetTestGithubRepos());

            controller = new HomeController(mockGithubUserService.Object, mockGithubRepoService.Object);
        }

        private GithubUser GetTestGithubUser()
        {
            var user = new GithubUser
            {
                Name = "Test User",
                Location = "Testington",
                Avatar_Url = "https://Test/Avatar/Url",
                Repos_Url = "https://Test/Repos/Url"
            };

            return user;
        }

        private IEnumerable<GithubRepo> GetTestGithubRepos()
        {
            var repos = new List<GithubRepo>();
            repos.Add(new GithubRepo
            {
                Name = "Test Repo",
                Html_Url = "https://Test/Repo",
                Stargazers_Count = 1
            });

            return repos;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }

            disposed = true;
        }
    }
}
