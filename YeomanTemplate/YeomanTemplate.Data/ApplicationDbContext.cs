using System.Data.Entity;
using System.Reflection;
using YeomanTemplate.Data.Base;
using YeomanTemplate.Models.Infrastructure;

namespace YeomanTemplate.Data {

    /// <summary>
    /// Database DbContext (EntityFramework) for current application
    /// </summary>
    public class ApplicationDbContext : DbContextBase, IAppContext {

        public ApplicationDbContext() : base("DefaultConnection") { }

        /// <summary>
        /// System events that logged by developer
        /// </summary>
        public IDbSet<LogItem> Logs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType()));
            base.OnModelCreating(modelBuilder);
        }
    }
}
