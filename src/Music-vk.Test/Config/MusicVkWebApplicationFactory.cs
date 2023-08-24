
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Myaudio.Application.Interface;
using Persistance.Base;

namespace Music_vk.Test.Config
{
    public class MusicVkWebApplicationFactory<TStartup> : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<Context>(options =>
                {
                    options.UseSqlite("Data Source=MusicVkBasse.db");
                });

            });
        }
    }
}

