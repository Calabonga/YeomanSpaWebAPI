using System;
using YeomanTemplate.Models.Infrastructure;

namespace <%= projectName %>.Models.Base {

    /// <summary>
    /// Represents the creation date and last update info as implementation for <see cref="IAuditable"/>
    /// </summary>
    public abstract class Auditable : Identity, IAuditable {

        /// <summary>
        /// Дата добавления в базу
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Property Обновление
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Last modifier
        /// </summary>
        public string UpdatedBy { get; set; }
    }
}