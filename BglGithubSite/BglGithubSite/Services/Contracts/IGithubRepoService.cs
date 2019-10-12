using BglGithubSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BglGithubSite.Services.Contracts
{
    public interface IGithubRepoService
    {
        IQueryable<GithubRepo> GetGithubRepos(string repos_url);
    }
}
