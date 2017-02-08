using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using <%= projectName %>.Models.Infrastructure;

namespace <%= projectName %>.Data.Configurations {

    /// <summary>
    /// Model configuration for LogItem (For demo purpose only)
    /// </summary>
    public class LogItemModelConfiguration : EntityTypeConfiguration<LogItem> {

        public LogItemModelConfiguration() {

            ToTable("ApplicationLogItem");

            HasKey(x => x.Id);

            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Message).HasMaxLength(1024).IsRequired();
            Property(x => x.CreatedAt).IsRequired();
            Property(x => x.LogType).IsRequired();
            Property(x => x.StackTrace).HasMaxLength(4096);
            Property(x => x.UserName).HasMaxLength(50);
        }
    }
}
