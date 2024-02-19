using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staff.Application.Contracts.Persistance;
using Staff.Infrastructure.Persistence;
using Staff.Infrastructure.Repositories;
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
            return services;
        }
    }
}
