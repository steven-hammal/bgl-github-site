using System.ComponentModel.DataAnnotations;

namespace BglGithubSite.Models
{
    public class Query
    {
        // This regular expression enforces the current requirments for a Github user name.  This will also protect against injection attacks since the hyphen is the only 
        // permissible non-alpha-numeric character.  This validation is enforced in the application but the validation message is not being displayed currently.
        [Required]
        [RegularExpression(@"^[a-z\d](?:[a-z\d]|-(?=[a-z\d])){0,38}$")] // Adpated from https://github.com/shinnn/github-username-regex
        public string Username { get; set; }
    }
}