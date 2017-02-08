using System;
using System.Data.Entity.Migrations;
using <%= projectName %>.Models.Infrastructure;

namespace <%= projectName %>.Data {

    public static class DbInitializer {

        public static void Initialize(ApplicationDbContext context) {

            var newLogItem = new LogItem() {
                CreatedAt = new DateTime(2017, 1, 1),
                Id = Guid.NewGuid(),
                LogType = LogType.Info,
                Message = "Seeding database...Ok",
                StackTrace = string.Empty,
                UserName = "Migration"
            };

            context.Logs.AddOrUpdate(newLogItem);
            context.SaveChanges();
        }
    }
}
