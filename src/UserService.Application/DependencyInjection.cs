using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.Api;
using UserService.Application.Api.AccessToken;
using UserService.Application.CQRS.Command.PostAuthorization;
using UserService.Application.CQRS.Querries.GetUserInfo;
using UserService.Application.Dto;
using UserService.Application.Interface;

namespace UserService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddSingleton<IVkaApi, VKApi>();
            services.AddScoped<GetUserInfoCommand>();
            services.AddScoped<GetUserInfoHandler>();
            services.AddScoped<UserInfoDto>();
            services.AddScoped<PostAuthorizationCommand>();
            services.AddScoped<PostAuthorizationHandler>();
            services.AddScoped<IVkaApi, VKApi>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccessToken, AccessToken>();


            return services;
        }
    }
}
