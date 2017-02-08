using System.Data.Entity;
using System.Reflection;
using <%= projectName %>.Data.Base;
using <%= projectName %>.Models.Infrastructure;

namespace <%= projectName %>.Data {

    /// <summary>
    /// Database DbContext (EntityFramework) for current application
    /// </summary>
    public class ApplicationDbContext : DbContextBase, IAppContext {

        public ApplicationDbContext() : base("DefaultConnection") { }

        /// <summary>
        /// System events that logged by developer
        /// </summary>
        public IDbSet<LogItem> Logs { get; set; }

        /// <summary>
        /// Models Configurations collecting
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType()));
            base.OnModelCreating(modelBuilder);
        }
    }
}
