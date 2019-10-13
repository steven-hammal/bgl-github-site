using System.Threading.Tasks;
using System.Web.Mvc;
using BglGithubSite.Services.Contracts;
using BglGithubSite.Models;
using BglGithubSite.ViewModels;

namespace BglGithubSite.Controllers
{

    public class HomeController : Controller
    {
        private readonly IGithubUserService githubUserService;
        private readonly IGithubRepoService githubRepoService;

        public HomeController(IGithubUserService githubUserService, IGithubRepoService githubRepoService)
        {
            this.githubUserService = githubUserService;
            this.githubRepoService = githubRepoService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Search(Query userQuery)
        {
            if (ModelState.IsValid)
            {
                var user = await githubUserService.GetGithubUser(userQuery);
                var repos = await githubRepoService.GetGithubRepos(user.Repos_Url);

                if (user == null)
                    return HttpNotFound();

                var searchResult = new GithubUserViewModel(user, repos);

                return View(searchResult);
            }
            return RedirectToAction("Index", userQuery);            
        }
    }
}