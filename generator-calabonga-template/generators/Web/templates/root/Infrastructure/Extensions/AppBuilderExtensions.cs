using Owin;
using <%= projectName %>.Web.Infrastructure.Owin;

namespace <%= projectName %>.Web.Infrastructure.Extensions {
    /// <summary>
    /// Static extensions for AppFunc
    /// </summary>
    public static class AppFuncExtensions {

        /// <summary>
        /// Use bearer authentication on cookie
        /// </summary>
        /// <param name="app"></param>
        public static void UseBearerOnCookieAuthentication(this IAppBuilder app) {
            app.Use<BearerOnCookieAuthentication>();
        }
    }
}
