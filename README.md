# bgl-github-site
A .net MVC site to retrieve and display a summary of data on a Github user.

Enter any search string into the text box on the landing page.  If the term is an existing Githuib user, some summary details (name, location) will be displayed along with the user's avatar and their top 5 repositories ranked by stargazers count.  Clicking any of the repository names will navigate to that repository on Github.

## Issues
* There is some code duplication between the services to retrieve users and repos.  Both use the same HttpClient which is registered as a singleton in the DI container.  There was a little confusion around the wording in the task document which states "Use the repos_url value to get a list of all the repos for the user".  An alternative would be to configure the HttpClient with the base Github api url and construct the repos url from that plus the username and '/repos'.  The implied appraoch fromm the instructions was used.

* Form validation error messages are not displayed, though the validation is enforced.  If there is a failure the site redirects to the home page, but no information is fed back to the user on how to remedy this.

* Test coverage is not as full as would have been possible with more time, the intent was to cover at least the happy path for all major functionality logic.

* Searching for a valid formatted user name which does not exist causes a non-fatal error, this could be handled more gracefully for the user by redirecting to the home page and displaying an appropriate message.
