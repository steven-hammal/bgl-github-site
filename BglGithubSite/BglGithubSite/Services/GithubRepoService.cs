using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using BglGithubSite.Models;
using BglGithubSite.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BglGithubSite.Services
{
    public class GithubRepoService : IGithubRepoService
    {
        private readonly HttpClient githubApiClient;
        public GithubRepoService(HttpClient client)
        {
            githubApiClient = client;
        }

        public async Task<IEnumerable<GithubRepo>> GetGithubRepos(string repos_url)
        {
            githubApiClient.DefaultRequestHeaders.Accept.Clear();
            githubApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            githubApiClient.DefaultRequestHeaders.Add("user-agent", ConfigurationManager.AppSettings["userAgent"]);

            var response = await githubApiClient.GetAsync(repos_url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var repos = JsonConvert.DeserializeObject<IEnumerable<GithubRepo>>(data);

                return repos;
            }
            else
            {
                throw new HttpException("Repos could not be retrived");
            }
        }
    }
}