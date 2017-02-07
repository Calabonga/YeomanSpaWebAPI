using System;
using YeomanTemplate.Models.Infrastructure;

namespace YeomanTemplate.Models.Base {
    /// <summary>
    /// Базовый класс сущности, которая имеет идентификатор
    /// </summary>
    public abstract class Identity : IHaveIdentifier {
        /// <summary>
        /// Property Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
