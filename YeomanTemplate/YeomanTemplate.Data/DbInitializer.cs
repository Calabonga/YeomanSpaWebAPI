using System;
using System.Data.Entity.Migrations;
using YeomanTemplate.Models.Infrastructure;

namespace YeomanTemplate.Data {
    public static class DbInitializer {
        public static void Initialize(ApplicationDbContext context) {
            var newLogItem = new LogItem() {
                CreatedAt = new DateTime(2017, 1, 1),
                Id = Guid.Parse("C4376CFE-5155-465F-A249-B11C7782760B"),
                LogType = LogType.Info,
                Message = "Method Seed applied",
                StackTrace = string.Empty,
                UserName = "SystemMigration"
            };

            context.Logs.AddOrUpdate(newLogItem);
            context.SaveChanges();
        }
    }
}
