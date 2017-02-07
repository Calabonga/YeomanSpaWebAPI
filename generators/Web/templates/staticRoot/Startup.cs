using Calabonga.Owin.Application;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using YeomanTemplateProject;

[assembly: OwinStartup(typeof(Startup))]
namespace YeomanTemplateProject {

    /// <summary>
    /// Startup for OWIN Middleware
    /// </summary>
    public class Startup {

        public void Configuration(IAppBuilder app) {

            // use WebAPI
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaulApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(config);
            
                                   
            // use Single Page Application middleware (should be last)
            app.UseSinglePageApplication();
        }
    }
}