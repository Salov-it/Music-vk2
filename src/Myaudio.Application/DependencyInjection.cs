using Microsoft.Extensions.DependencyInjection;
using Myaudio.Application.CQRS.Command.PostDownloadAudio;
using Myaudio.Application.Interface;
using System.Reflection;

namespace Myaudio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services.AddScoped<>():

            services.AddScoped<ILooadin, LoadingMp3>();
            services.AddScoped<PostDownloadAudioCommand>();
            services.AddScoped<PostDownloadAudioHandler>();
            return services;
        }
    }
}
