using UrlShortner.Application.Contracts;
using UrlShortner.Application.Services.Memory;

namespace UrlShortner.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryShortner(this IServiceCollection services)
        {
            services.AddScoped<IUrlResolver, UrlResolverService>();
            services.AddScoped<IUrlShortner, UrlShorteningService>();
            services.AddSingleton<IUrlPersistance, UrlPersistanceService>();
            services.AddScoped<Application.UrlShortener>();
            return services;
        }
    }
}
