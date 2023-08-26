using AudioPopularService.Application.CQRS.Command.GetAudioPopular;
using AudioPopularService.Application.CQRS.Command.PostDownloadAudio;
using AudioPopularService.Application.Interface;
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
            services.AddScoped<GetAudioPopulaCommand>();
            services.AddScoped<GetAudioPopulaHandler>();
            services.AddScoped<IAudioPopular, AudioPopular>();
            services.AddScoped<IAudioPopulaRepository,AudioPopularRepository>();
            services.AddScoped<ILooadin, LoadingMp3>();
            


            return services;
        }
    }
}
