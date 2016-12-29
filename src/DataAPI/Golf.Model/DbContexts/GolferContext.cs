using Golf.Model.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Golf.Model.DbContexts
{
    public class GolferContext : DbContext
    {
        public GolferContext(DbContextOptions<GolferContext> options)
            : base(options)
        {
        }

        public DbSet<Golfer> Golfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Golfer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = ClaimsPrincipal.Current.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
