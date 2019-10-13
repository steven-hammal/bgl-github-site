namespace BglGithubSite.Models
{
    // Rationale here is that any future requirments to search non-Github source control services are likely to always have these fields
    public abstract class BaseCodeRepo
    {
        public string Name { get; set; }
        public string Html_Url { get; set; }
    }
}