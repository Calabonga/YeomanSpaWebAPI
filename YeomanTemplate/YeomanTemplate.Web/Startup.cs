using Calabonga.Owin.Application;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using System;
using Autofac;
using Microsoft.Owin.Security;
using YeomanTemplate.Web;
using YeomanTemplate.Web.Infrastructure.Extensions;
using YeomanTemplate.Web.Infrastructure.OAuth;

[assembly: OwinStartup(typeof(Startup))]
namespace YeomanTemplate.Web {

    /// <summary>
    /// Startup for OWIN Middleware
    /// </summary>
    public class Startup {

        /// <summary>
        /// Server OAuthorization Options
        /// </summary>
        public static OAuthAuthorizationServerOptions OAuthAuthorizationServerOptions { get; set; }

        /// <summary>
        /// Bearer authentication options
        /// </summary>
        public static OAuthBearerAuthenticationOptions OAuthBearerAuthenticationOptions { get; set; }

        public void Configuration(IAppBuilder app) {


            var config = ConfigurationBuilder.Create();
            var container = DependencyContainer.Initialize();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            var provider = container.Resolve<ApplicationOAuthProvider>();
            OAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions {
                AllowInsecureHttp = true,
                AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                AuthenticationMode = AuthenticationMode.Active,
                TokenEndpointPath = new PathString("/token-endpoint"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AuthorizationCodeExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = provider
            };
            app.UseOAuthAuthorizationServer(OAuthAuthorizationServerOptions);
            app.UseBearerOnCookieAuthentication();
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            OAuthBearerAuthenticationOptions = new OAuthBearerAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                AuthenticationMode = AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(OAuthBearerAuthenticationOptions);
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseSinglePageApplication();

        }
    }
}