using HotelierProject.WebUI.Services.Abstract;
using HotelierProject.WebUI.Services.Concrete;

namespace HotelierProject.WebUI.Extensions;

public static class ServiceRegistrations
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // User Secrets içindeki key'iniz:
        var rawUrl = configuration["BaseUrl"] ?? configuration["ApiSettings:BaseUrl"];
        var baseUrl = new Uri(rawUrl!);

        // Tek bir noktadan tüm HttpClient'ların BaseAddress'ini ayarlar:
        services.ConfigureHttpClientDefaults(builder =>
        {
            builder.ConfigureHttpClient(client => client.BaseAddress = baseUrl);
        });

        services.AddHttpClient<IStaffApiService, StaffApiService>();
        services.AddHttpClient<IRoomApiService, RoomApiService>();
        services.AddHttpClient<IServiceApiService, ServiceApiService>();
        services.AddHttpClient<ITestimonialApiService, TestimonialApiService>();
        services.AddHttpClient<ISubscribeApiService, SubscribeApiService>();

        return services;
    }
}