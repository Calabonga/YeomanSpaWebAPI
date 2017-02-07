using Calabonga.PagedListLite;
using YeomanTemplate.Models.Infrastructure;
using YeomanTemplate.Web.Infrastructure.Dto;
using YeomanTemplate.Web.Infrastructure.Mapper.Base;

namespace YeomanTemplate.Web.Infrastructure.Mapper {

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