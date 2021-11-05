using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebApplication.EfCore
{
    public class MyDbContext: DbContext
    {
        private readonly TenantFilterProvider _tenantFilterProvider;
        public DbSet<MyEntity> Entities { get; set; }

        public MyDbContext(TenantFilterProvider tenantFilterProvider)
        {
            _tenantFilterProvider = tenantFilterProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\aa.db");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var filter = _tenantFilterProvider.GetExpression();

            modelBuilder.Entity<MyEntity>()
                .HasQueryFilter(filter);
        }
    }
}