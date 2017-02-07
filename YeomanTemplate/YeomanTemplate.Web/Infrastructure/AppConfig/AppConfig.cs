using Calabonga.Portal.Config;

namespace YeomanTemplate.Web.Infrastructure.AppConfig {
    /// <summary>
    /// Config service
    /// </summary>
    public class AppConfig : ConfigServiceBase<CurrentAppSettings>, IAppConfig {

        public AppConfig(IConfigSerializer serializer, ICacheService cacheService)
            : base(serializer, cacheService) { }

        public AppConfig(string configFileName, IConfigSerializer serializer, ICacheService cacheService)
            : base(configFileName, serializer, cacheService) { }
    }
}