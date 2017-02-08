using System;
using <%= projectName %>.Models.Base;

namespace <%= projectName %>.Web.Infrastructure.Models {

    /// <summary>
    /// Represents the User profile
    /// </summary>
    public class UserProfile : Identity {

        public string AuthenticationType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The list of the user roles (permissions)
        /// </summary>
        public string[] Roles { get; set; }
    }
}
