﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.Api;
using UserService.Application.Interface;

namespace UserService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddSingleton<IVkaApi, VKApi>();
  
            return services;
        }
    }
}