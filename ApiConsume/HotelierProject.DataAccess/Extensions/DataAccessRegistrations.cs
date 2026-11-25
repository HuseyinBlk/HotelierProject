using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.DataAccess.EntityFramework;
using HotelierProject.DataAccess.Interceptors;
using HotelierProject.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelierProject.DataAccess.Extensions;

public static class DataAccessRegistrations
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditDbContextInterceptor>();

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            options.AddInterceptors(sp.GetRequiredService<AuditDbContextInterceptor>());
        });

        services.AddScoped<IUnitOfWork, HotelierProject.DataAccess.UnitOfWork.UnitOfWork>();

        services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

        // Scrutor: Sonu Dal veya Repository ile biten sınıfları otomatik kaydet
        services.Scan(scan => scan
            .FromAssemblyOf<AppDbContext>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Dal") || type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
