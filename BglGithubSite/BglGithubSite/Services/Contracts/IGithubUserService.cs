using BglGithubSite.Models;
using System.Threading.Tasks;

namespace BglGithubSite.Services.Contracts
{
    public interface IGithubUserService
    {
        Task<GithubUser> GetGithubUser(Query userQuery);
    }
}