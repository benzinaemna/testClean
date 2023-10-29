using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.Contracts.Persistence;
using Test.Persistance.Context;
using Test.Persistance.Repositories;

namespace Test.Persistance;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestContext>(options =>

            options.UseSqlServer(configuration.GetConnectionString("MyDataBAseConnectionString"))
        );
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}
