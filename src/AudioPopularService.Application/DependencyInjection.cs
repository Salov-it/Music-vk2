using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AudioPopularService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAudioPopularService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services.AddScoped<>():
           

            return services;
        }
    }
}
