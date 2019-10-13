using System.Threading.Tasks;
using System.Web.Mvc;
using BglGithubSite.Services.Contracts;
using BglGithubSite.Models;
using BglGithubSite.ViewModels;
using System;

namespace BglGithubSite.Controllers
{
    public class HomeController : Controller
    {
        // Next step: Refactor into a single GithubApiService
        private readonly IGithubUserService _githubUserService;
        private readonly IGithubRepoService _githubRepoService;

        public HomeController(IGithubUserService githubUserService, IGithubRepoService githubRepoService)
        {
            this._githubUserService = githubUserService;
            this._githubRepoService = githubRepoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Search(Query userQuery)
        {
            // Field validation using data annotation passes testing but message will not appear in the Index view
            if (ModelState.IsValid)
            {
                var user = await _githubUserService.GetGithubUser(userQuery);

                if (user == null)
                    return HttpNotFound(); 
                
                var repos = await _githubRepoService.GetGithubRepos(user.Repos_Url);

                var searchResult = new GithubUserViewModel(user, repos);

                return View(searchResult);
            }
            return View("Index", userQuery);            
        }
    }
}