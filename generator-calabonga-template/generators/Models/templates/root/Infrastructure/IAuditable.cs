using System;

namespace <%= projectName %>.Models.Infrastructure {

    /// <summary>
    /// Represents the creation date and last update info
    /// </summary>
    public interface IAuditable {

        /// <summary>
        /// Дата добавления в базу
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Property Обновление
        /// </summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Last modifier
        /// </summary>
        string UpdatedBy { get; set; }
    }
}
