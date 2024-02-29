using Microsoft.EntityFrameworkCore;
using Staff.Domain.Common;
using Staff.Domain.Entities.Constant;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Junction;
using Staff.Domain.Entities.Staff;

namespace Staff.Infrastructure.Persistence
{
    public class StaffDbContext:DbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options):base(options)
        {
                
        }

        //Staff Information Related Models
        public DbSet<StaffPersonalInfo> StaffInfos { get; set; }
        public DbSet<StaffEducationDetail> EducationDetails { get; set; }
        public DbSet<StaffEmploymentDetail> EmploymentDetails { get; set; }
        public DbSet<StaffPositionLevel> StaffPositionLevels { get; set; }
        public DbSet<StaffEmploymentType> StaffEmploymentTypes { get; set; }    
        public DbSet<StaffEmploymentStatus> StaffEmploymentStatuses { get; set; }

        //Staff Department information Related Models
        public DbSet<DepartmentCategory> DepartmentCategories { get; set; }
        public DbSet<DepartmentInfo> DepartmentInfos { get; set; }
        public DbSet<EmploymentDetailDepartment> EmploymentStatusDepartments { get; set; }

        //Staff Degree Information Related Models
        public DbSet<DegreeLevel> DegreeLevels { get; set; }

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

           
            modelBuilder.Entity<StaffEmploymentDetail>()
                .HasOne(a => a.StaffInfo)
                .WithOne(b => b.EmploymentDetail)
                .HasForeignKey<StaffEmploymentDetail>(b => b.StaffId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StaffEmploymentDetail>()
               .HasOne(a => a.PositionLevel)
               .WithMany(b => b.EmploymentDetails)
               .HasForeignKey(b => b.PositionLevelId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<StaffEmploymentDetail>()
               .HasOne(a => a.Status)
               .WithMany(b => b.EmploymentDetails)
               .HasForeignKey(b => b.StatusId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<StaffEmploymentDetail>()
               .HasOne(a => a.Type)
               .WithMany(b => b.EmploymentDetails)
               .HasForeignKey(b => b.TypeId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmploymentDetailDepartment>()
                .HasKey(a => new { a.DepartmentInfoId, a.EmploymentDetialId });

            modelBuilder.Entity<EmploymentDetailDepartment>()
                .HasOne(esd => esd.DepartmentInfo)
                .WithMany(d => d.EmploymentDetails)
                .HasForeignKey(esd => esd.DepartmentInfoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmploymentDetailDepartment>()
                .HasOne(esd => esd.EmploymentDetail)
                .WithMany(es => es.DepartmentInfos)
                .HasForeignKey(esd => esd.EmploymentDetialId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StaffEducationDetail>()
             .HasOne(b => b.Staff)
             .WithMany(a => a.EducationDetails)
             .HasForeignKey(b => b.StaffId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StaffEducationDetail>()
             .HasOne(b => b.DegreeLevel)
             .WithMany(a => a.EducationDetials)
             .HasForeignKey(b => b.DegreeLevelId);


            modelBuilder.Entity<DepartmentInfo>()
                .HasOne(a => a.DepartmentCategory)
                .WithMany(b => b.DepartmentInfos)
                .HasForeignKey(b => b.DepartmentCategoryId);

            modelBuilder.Entity<StaffEmploymentDetail>()
                .HasOne(a => a.DepartmentCategory)
                .WithMany(b => b.EmploymentDetails)
                .HasForeignKey(b => b.DepartmentCategoryId);

            

            


        }
    }
}
