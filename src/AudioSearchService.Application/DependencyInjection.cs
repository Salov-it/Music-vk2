using AudioSearchService.Application.CQRS.Command.GetAudioSearch;
using AudioSearchService.Application.CQRS.Command.PostAudioSearch;
using AudioSearchService.Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ILooadin = AudioSearchService.Application.Interface.ILooadin;
namespace AudioSearchService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAudioSearchService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services.AddScoped<>():
            services.AddScoped<PostAudioSearchCommand>();
            services.AddScoped<PostAudioSearchHandler>();
            services.AddScoped<IAudioSearch, AudioSearch>();
            services.AddScoped<IAudioSearchRepository, AuduioSearchRepository>();
            services.AddScoped<ILooadin, LoadingMp3>();
            services.AddScoped<IAudioSearch, AudioSearch>();

            return services;
        }
    }
}
