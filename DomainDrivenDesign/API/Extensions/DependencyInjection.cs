using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Domain.Interfaces;
using Domain.Interfaces.Department;
using Domain.Interfaces.Employee;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("Employee");
            });
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>))
                .AddScoped<IUnitOfWork,UnitOfWork>()
                .AddScoped<IEmployeeRepository,EmployeeRepository>()
                .AddScoped<IDepartmentRepository,DepartmentRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<DepartmentService>();
            return services;
        }
    }
}
