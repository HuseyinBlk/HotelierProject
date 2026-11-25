using HotelierProject.Business.Abstract;
using HotelierProject.Business.Concrete;
using HotelierProject.Entity.Common;
using Microsoft.Extensions.DependencyInjection;

namespace HotelierProject.Business.Extensions;

public static class BusinessRegistrations
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {

        services.Scan(scan => scan
            .FromAssemblyOf<RoomManager>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Manager") || type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
