using System.Collections.Generic;
using System.Web.Http;
using Calabonga.OperationResults;

namespace $rootnamespace$.Controllers {

    public class ValuesController : ApiController {

        public IHttpActionResult Get() {
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