using BglGithubSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BglGithubSite.Services.Contracts
{
    public interface IGithubRepoService
    {
        Task<IEnumerable<GithubRepo>> GetGithubRepos(string repos_url);
    }
}
