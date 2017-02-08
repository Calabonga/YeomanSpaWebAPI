namespace <%= projectName %>.Web.Infrastructure.AppConfig {

    /// <summary>
    /// Config service interface
    /// </summary>
    public interface IAppConfig {
        /// <summary>
        /// Application settings stored in AppConfig.cfg file
        /// </summary>
        CurrentAppSettings Config { get; }
    }
}
