using Microsoft.Extensions.Logging;
using Staff.Domain.Entities;
using Staff.Domain.Entities.Department;
using Staff.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure.Persistence
{
    public class StaffDbContextSeed
    {
        public static async Task SeedAsync(StaffDbContext context,ILogger<StaffDbContextSeed> logger)
        {
            if (!context.DegreeLevels.Any()) context.DegreeLevels.AddRange(GetPreConfigDegreeLevels());
            if (!context.DepartmentCategories.Any()) context.DepartmentCategories.AddRange(GetPreConfigDepartmentCategories());
            if (!context.DepartmentInfos.Any()) context.DepartmentInfos.AddRange(GetPreConfigDepartmentInfos());
            if (!context.StaffPositionLevels.Any()) context.StaffPositionLevels.AddRange(GetPreConfigPositionLevels());
            if (!context.StaffEmploymentStatuses.Any()) context.StaffEmploymentStatuses.AddRange(GetPreConfigEmploymentStatuses());
            if (!context.StaffEmploymentTypes.Any()) context.StaffEmploymentTypes.AddRange(GetPreConfigEmploymentTypes());
            await context.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(StaffDbContext).Name);
        }

        public static IEnumerable<DegreeLevel> GetPreConfigDegreeLevels()
        {
            return new List<DegreeLevel>()
            {
                new DegreeLevel(){Level="Grauduation"},
                new DegreeLevel(){Level="Masters"}
            };
        }

        public static IEnumerable<DepartmentCategory> GetPreConfigDepartmentCategories()
        {
            return new List<DepartmentCategory>()
            {
                new DepartmentCategory(){Name="Teaching"},
                new DepartmentCategory(){Name="Non Teaching"}
            };
        }
        public static IEnumerable<DepartmentInfo> GetPreConfigDepartmentInfos()
        {
            return new List<DepartmentInfo>()
            {
                new DepartmentInfo(){Name="OOPs",DepartmentCategoryId=1},
                new DepartmentInfo(){Name="DLD",DepartmentCategoryId=1},
                new DepartmentInfo(){Name="Calculas",DepartmentCategoryId=1},
                new DepartmentInfo(){Name="Driver",DepartmentCategoryId=2},
                new DepartmentInfo(){Name="Principal",DepartmentCategoryId=2},
                new DepartmentInfo(){Name="Incharge",DepartmentCategoryId=2},

            };
        }
        public static IEnumerable<StaffPositionLevel> GetPreConfigPositionLevels()
        {
            return new List<StaffPositionLevel>()
            {
                new StaffPositionLevel(){Level="Fresh"},
                new StaffPositionLevel(){Level="Senior"},
                new StaffPositionLevel(){Level="Mid"}
            };
        }
        public static IEnumerable<StaffEmploymentStatus> GetPreConfigEmploymentStatuses()
        {
            return new List<StaffEmploymentStatus>()
            {
                new StaffEmploymentStatus(){Status="Resigned"},
                new StaffEmploymentStatus(){Status="Employed"},
                new StaffEmploymentStatus(){Status="Terminated"}
            };
        }
        public static IEnumerable<StaffEmploymentType> GetPreConfigEmploymentTypes()
        {
            return new List<StaffEmploymentType>()
            {
                new StaffEmploymentType(){Type="Permanent"},
                new StaffEmploymentType(){Type="Contractual"},
                new StaffEmploymentType(){Type="Contractual Part time"},
                new StaffEmploymentType(){Type="Contractual Full time"},

            };
        }
    }
}
