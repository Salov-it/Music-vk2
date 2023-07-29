using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyRecommendationsService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationMyRecom(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services.AddScoped<>():
            return services;
        }
    }
}
