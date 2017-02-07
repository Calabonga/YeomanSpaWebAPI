using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using Microsoft.AspNet.Identity.EntityFramework;
using YeomanTemplate.Models.Infrastructure;

namespace YeomanTemplate.Data.Base {
    public abstract class DbContextBase : IdentityDbContext<ApplicationUser>, IDbContext {

        protected DbContextBase(string defaultConnection) : base(defaultConnection) {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;

            _lastOPerationResult = new SaveChangesResult();
        }

        private SaveChangesResult _lastOPerationResult;

        /// <summary>
        /// Last saving operation result
        /// </summary>
        public SaveChangesResult LastSaveChangesResult {
            get { return _lastOPerationResult; }
        }

        /// <summary>
        /// Last SaveChange operation result
        /// </summary>

        public override int SaveChanges() {

            try {
                _lastOPerationResult = new SaveChangesResult();
                var createdSourceInfo = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
                var modifiedSourceInfo = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

                foreach (var entry in createdSourceInfo) {
                    if (entry.Entity.GetType().GetInterfaces().Contains(typeof(IAuditable))) {
                        var creationDate = DateTime.Now;
                        entry.Property("CreatedAt").CurrentValue = creationDate;
                        entry.Property("UpdatedAt").CurrentValue = creationDate;

                        string userName = Thread.CurrentPrincipal.Identity?.Name ?? "Anonymous";
                        //entry.Property("CreatedBy").CurrentValue = userName;
                        entry.Property("UpdatedBy").CurrentValue = userName;


                        _lastOPerationResult.AddMessage($"ChangeTracker has new entities: {entry.Entity.GetType()}");
                    }
                }
                foreach (var entry in modifiedSourceInfo) {
                    if (entry.Entity.GetType().GetInterfaces().Contains(typeof(IAuditable))) {
                        entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    }
                    _lastOPerationResult.AddMessage($"ChangeTracker has modified entities: {entry.Entity.GetType()}");
                }
                return base.SaveChanges();
            }
            catch (DbUpdateException exception) {
                _lastOPerationResult.Exception = exception;
                return 0;
            }
        }
    }
}