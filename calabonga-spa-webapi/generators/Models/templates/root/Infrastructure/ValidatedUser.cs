using System.Collections.Generic;
using System.Security.Claims;

namespace <%= projectName %>.Models.Infrastructure {
    /// <summary>
    /// User validated because founed in the user list
    /// </summary>
    public class ValidatedUser {

        public string UserName { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}
