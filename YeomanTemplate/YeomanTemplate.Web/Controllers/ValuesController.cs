using System.Collections.Generic;
using System.Web.Http;
using Calabonga.OperationResults;
using YeomanTemplate.Web.Infrastructure.Services;

namespace YeomanTemplate.Controllers {

    /// <summary>
    /// Demo controller with dependency injection
    /// </summary>
    public class ValuesController : ApiController {

        private readonly ILogService _logService;

        public ValuesController(ILogService logService) {
            _logService = logService;
        }

        public IHttpActionResult Get() {
            _logService.LogInfo("ILogService successfully injected to ApiController!");
            var items = new List<string>
            {
                "Value 1",
                "Value 2",
                "Value 3",
                "Value 4",
                "Value 5",
                "Value 6",
            };
            return Ok(OperationResult.CreateResult(items));
        }
    }
}