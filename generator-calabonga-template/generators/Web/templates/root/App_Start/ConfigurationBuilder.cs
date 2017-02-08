using System.Globalization;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using <%= projectName %>.Web.Infrastructure.OAuth;

namespace <%= projectName %>.Web {

    /// <summary>
    /// HttpConfiguration builder
    /// </summary>
    public static class ConfigurationBuilder {
        public static HttpConfiguration Create() {
            var config = new HttpConfiguration();

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new AuthorizationBearerFilter());

            // Attribute routing.
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // formatter settings
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.Culture = CultureInfo.CurrentCulture;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


            return config;
        }
    }
}
