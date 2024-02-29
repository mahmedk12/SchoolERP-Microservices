using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staff.Application.Contracts.Persistance.Constant;
using Staff.Application.Contracts.Persistance.Department;
using Staff.Application.Contracts.Persistance.Generic;
using Staff.Application.Contracts.Persistance.Staff;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories.Constant;
using Staff.Infrastructure.Repositories.Department;
using Staff.Infrastructure.Repositories.Generic;
using Staff.Infrastructure.Repositories.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Infrastructure
{
    public static class InfraStructureServiceRegisteration
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StaffDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StaffConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IDegreeLevelRepository,DegreeLevelRepository >();
            services.AddScoped<IDepartmentCategoryRepository,DepartmentCategoryRepository >();
            services.AddScoped<IDepartmentInfoRepository,DepartmentInfoRepository >();
            services.AddScoped<IPositionLevelRepository,PositionLevelRepository >();
            services.AddScoped<IEmploymentTypeRepository,EmploymentTypeRepository >();
            services.AddScoped<IEmploymentStatusRepository,EmploymentStatusRepository >();
            return services;
        }
    }
}
