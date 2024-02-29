using AutoMapper.Internal;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Staff.Application.Behaviours;
using Staff.Application.Features.Staff.Commands.CreateStaff;
using Staff.Application.Features.Staff.Queries.Dtos;
using System.Reflection;

namespace Staff.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(ApplicationServiceRegisteration).Assembly;
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient<IRequestHandler<CreateStaffCommand, ApiResponse<GetStaffDto>>, CreateStaffCommandHandler>();

            return services;
        }
    }
}
