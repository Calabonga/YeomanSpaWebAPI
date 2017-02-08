using AutoMapper;
using <%= projectName %>.Data.Base;
using <%= projectName %>.Models.Infrastructure;
using <%= projectName %>.Web.Infrastructure.AppConfig;
using <%= projectName %>.Web.Infrastructure.QueryParams;
using <%= projectName %>.Web.Infrastructure.Services;
using <%= projectName %>.Web.Infrastructure.Services.Base;

/*
 * This file only for demo of using ReadableRepository!
 * The ILogService already exists in folder: /Infrastructure/Services/LogService.cs
 * That is why you can delete this class and create you needed for
 * Read more in the article of my blog http://www.calabonga.net/blog/post/186 (rus)
 */

namespace <%= projectName %>.Web.Infrastructure.Repositories {

    /// <summary>
    /// Log item repository for system event saving
    /// </summary>
    public class LogRepository : ReadableRepositoryBase<LogItem, PagedListQueryParams> {
        public LogRepository(IAppContext context, IAppConfig config, IMapper mapper, IServiceSettings settings, ILogService logger)
            : base(context, config, mapper, settings, logger) {

        }
    }
}
