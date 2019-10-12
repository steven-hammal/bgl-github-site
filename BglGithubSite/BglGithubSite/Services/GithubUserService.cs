using BglGithubSite.Models;
using BglGithubSite.Services.Contracts;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BglGithubSite.Services
{
    public class GithubUserService : IGithubUserService
    {
        private readonly HttpClient githubApiClient;

        public GithubUserService(HttpClient client)
        {
            githubApiClient = client;
        }

        public async Task<GithubUser> GetGithubUser(Query userQuery)
        {
            var searchUrl = ConfigurationManager.AppSettings["githubUsersUrl"] + userQuery.Username;

            githubApiClient.DefaultRequestHeaders.Accept.Clear();
            githubApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            githubApiClient.DefaultRequestHeaders.Add("user-agent", ConfigurationManager.AppSettings["userAgent"]);

            var response = await githubApiClient.GetAsync(searchUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var githubUser = JsonConvert.DeserializeObject<GithubUser>(data);

                return githubUser;
            }
            else
            {
                throw new HttpException($"User {userQuery.Username} not found");
            }
        }
    }
}