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
    public abstract class UserServiceTestsBase : IDisposable
    {
        public GithubUserService service;
        bool disposed = false;
        protected UserServiceTestsBase()
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
                                       Content = new StringContent("{'name':'Test Name', 'location': 'Testington', 'avatar_url': 'https://test/test_avatar/avatar.png', 'repos_url': 'https://test/test-user-name/repos'}"),
                                   }).Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["githubUsersUrl"]),
            };

            service = new GithubUserService(httpClient);
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
