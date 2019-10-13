namespace BglGithubSite.Models
{
    public class GithubRepo : BaseCodeRepo
    {
        // Stargazers_count likely to be Github specific, therefore extend the base class to include this so any future implementation is closed to modification 
        public int Stargazers_Count { get; set; }
    }
}