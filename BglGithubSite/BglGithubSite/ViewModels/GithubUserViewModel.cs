using System.Collections.Generic;
using System.Linq;
using BglGithubSite.Models;

namespace BglGithubSite.ViewModels
{
    public class GithubUserViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Avatar_Url { get; set; }

        // The Github repo service will return all repositories for a user (as stated in the requirements).  
        // Selection of the top 5 is deferred until presentation.
        public IEnumerable<GithubRepo> TopFiveRepos { get; set; }

        public GithubUserViewModel(GithubUser user, IEnumerable<GithubRepo> repos)
        {
            Name = user.Name;
            Location = user.Location;
            Avatar_Url = user.Avatar_Url;

            TopFiveRepos = repos.OrderByDescending(repo => repo.Stargazers_Count).Take(5);
        }

    }
}