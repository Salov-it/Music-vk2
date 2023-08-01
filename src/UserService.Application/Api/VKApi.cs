using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interface;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using UserService.Application.Config;

namespace UserService.Application.Api
{
    public class VKApi : IVkaApi
    {
        public void ApiAut(string Login, string Password, ulong ApplicationId) 
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var Api = new VkApi(services);
            Configs configs = new Configs();
    

            Api.Authorize(new ApiAuthParams
            {
                  ApplicationId = ApplicationId,
                  Login = Login,
                  Password = Password,
            });
            var accessToken = Api.Token;
            configs.AccessToken = accessToken;
            Console.WriteLine($"Токен:{accessToken}");
        }
    }
}
