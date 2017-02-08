using System.Collections.Generic;
using System.Security.Claims;

namespace <%= projectName %>.Web.Infrastructure.Models {

    /// <summary>
    /// User validated because founded in the user list
    /// </summary>
    public class ValidatedUser {

        public string UserName { get; set; }

        public IEnumerable<Claim> Claims { get; set; }
    }
}
