using System.Data.Entity;
using <%= projectName %>.Models.Infrastructure;

namespace <%= projectName %>.Data.Base {

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
