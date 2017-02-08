using System;
using <%= projectName %>.Models.Infrastructure;

namespace <%= projectName %>.Models.Base {
    /// <summary>
    /// Base indetifier
    /// </summary>
    public abstract class Identity : IHaveIdentifier {

        /// <summary>
        /// Property Identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
