using System.ComponentModel.DataAnnotations;

namespace BglGithubSite.Models
{
    public class Query
    {
        [Required]
        [RegularExpression(@"^[a-z\d](?:[a-z\d]|-(?=[a-z\d])){0,38}$")] // Adpated from https://github.com/shinnn/github-username-regex
        public string Username { get; set; }
    }
}