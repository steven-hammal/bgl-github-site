using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BglGithubSite.Models
{
    public class GithubRepo : BaseCodeRepo
    {
        public int Stargazers_Count { get; set; }
    }
}