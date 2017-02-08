using AutoMapper;
using <%= projectName %>.Data.Base;
using <%= projectName %>.Models.Infrastructure;
using <%= projectName %>.Web.Infrastructure.AppConfig;
using <%= projectName %>.Web.Infrastructure.QueryParams;
using <%= projectName %>.Web.Infrastructure.Services;
using <%= projectName %>.Web.Infrastructure.Services.Base;

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
