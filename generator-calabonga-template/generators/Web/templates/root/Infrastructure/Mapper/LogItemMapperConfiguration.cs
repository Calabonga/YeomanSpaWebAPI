using Calabonga.PagedListLite;
using <%= projectName %>.Models.Infrastructure;
using <%= projectName %>.Web.Infrastructure.Dto;
using <%= projectName %>.Web.Infrastructure.Mapper.Base;

namespace <%= projectName %>.Web.Infrastructure.Mapper {

    /// <summary>
    /// Mapper configuration for AccidentType entity
    /// </summary>
    public class LogItemMapperConfiguration : MapperConfigurationBase {

        public LogItemMapperConfiguration() {
            CreateMap<LogItem, LogItemDto>()
                .ForMember(x => x.LogType, o => o.MapFrom(c => c.LogType.ToString()));


            CreateMap<PagedList<LogItem>, PagedList<LogItemDto>>()
                .ConvertUsing<PagedListConverter<LogItem, LogItemDto>>();

        }
    }
}
