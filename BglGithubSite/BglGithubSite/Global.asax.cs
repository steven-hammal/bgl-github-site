using Autofac;
using Autofac.Integration.Mvc;
using BglGithubSite.Services;
using BglGithubSite.Services.Contracts;
using System.Net.Http;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BglGithubSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.Register(ctx => new HttpClient())
                .SingleInstance();

            builder.RegisterType<GithubUserService>().As<IGithubUserService>();
            builder.RegisterType<GithubRepoService>().As<IGithubRepoService>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
