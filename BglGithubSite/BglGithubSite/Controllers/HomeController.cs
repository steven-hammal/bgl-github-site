using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BglGithubSite.Services.Contracts;
using BglGithubSite.Models;

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

        public async Task<ActionResult> Search(Query userQuery)
        {
            var user = await githubUserService.GetGithubUser(userQuery);

            if(user == null)
                return HttpNotFound();

            return View(user);
        }
    }
}