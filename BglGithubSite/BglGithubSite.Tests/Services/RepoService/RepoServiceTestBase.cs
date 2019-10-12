using BglGithubSite.Services;
using Moq;
using Moq.Protected;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BglGithubSite.Tests.Services
{
    public abstract class RepoServiceTestsBase : IDisposable
    {
        public GithubRepoService service;
        bool disposed = false;
        protected RepoServiceTestsBase()
        {
            // Method of mocking HttpClient (which has no interface) from https://gingter.org/2018/07/26/how-to-mock-httpclient-in-your-net-c-unit-tests/
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                                      "SendAsync",
                                      ItExpr.IsAny<HttpRequestMessage>(),
                                      ItExpr.IsAny<CancellationToken>()
                                   ).ReturnsAsync(new HttpResponseMessage()
                                   {
                                       StatusCode = HttpStatusCode.OK,
                                       Content = new StringContent("[{'name':'Test Repo', 'html_url': 'https://test/test_repo/repo', 'stargazers_count': 1}]"),
                                   }).Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["githubUsersUrl"]),
            };

            service = new GithubRepoService(httpClient);
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

