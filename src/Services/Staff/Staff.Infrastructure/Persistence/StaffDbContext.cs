using Microsoft.EntityFrameworkCore;
using Staff.Domain.Common;
using Staff.Domain.Entities;

namespace Staff.Infrastructure.Persistence
{
    public class StaffDbContext:DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options):base(options)
        {
                
        }

        public DbSet<StaffPersonalInfo> StaffInfos { get; set; }
        public DbSet<StaffEducationDetail> EducationDetails { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffEducationDetail>()
             .HasOne(b => b.Staff)
             .WithMany(a => a.educationDetails)
             .HasForeignKey(b => b.staffId);
        }
    }
}
