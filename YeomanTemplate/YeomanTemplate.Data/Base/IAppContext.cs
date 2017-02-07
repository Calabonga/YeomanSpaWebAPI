using System.Data.Entity;
using YeomanTemplate.Models.Infrastructure;

namespace YeomanTemplate.Data.Base {

    /// <summary>
    /// Facts DbContext
    /// </summary>
    public interface IAppContext : IDbContext {

        #region Application models

        /// <summary>
        /// System events that logged by developer
        /// </summary>
        IDbSet<LogItem> Logs { get; set; }

        #endregion
    }
}