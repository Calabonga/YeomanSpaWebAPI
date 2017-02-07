using System;

namespace <%= projectName %>.Models.Infrastructure {

    /// <summary>
    /// Unique identifier for entity
    /// </summary>
    public interface IHaveIdentifier {

        /// <summary>
        /// Identifier for entity
        /// </summary>
        Guid Id { get; set; }
    }
}
