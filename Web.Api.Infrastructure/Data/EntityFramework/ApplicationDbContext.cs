using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Api.Infrastructure.Data.Entities;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;


namespace Web.Api.Infrastructure.Data.EntityFramework
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<JobEntity> Jobs { get; set; }

        public DbSet<JobItemEntity> JobItems { get; set; }
        public DbSet<JobLogEntity> JobLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JobEntity>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired();
            });

            builder.Entity<JobItemEntity>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired();

                entity.Property(e => e.DataSourceUrl)
                    .IsRequired();

                entity.Property(e => e.JobId)
                    .IsRequired();
            });

            builder.Entity<JobLogEntity>(entity =>
            {
                entity.Property(e => e.JobId)
                    .IsRequired();

                entity.Property(e => e.JobType)
                    .IsRequired();

                entity.Property(e => e.JobItemId)
                    .IsRequired();

                entity.Property(e => e.DataSourceUrl)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired();

                entity.Property(e => e.Error)
                    .IsRequired();
            });

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
