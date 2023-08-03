using Microsoft.Extensions.DependencyInjection;
using Myaudio.Application.CQRS.Interface;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using UserService.Application.CQRS.Command.PostAuthorization;
using UserService.Application.Interface;
using UserService.Application.Config;

namespace Myaudio.Application.CQRS.Command.GetMyaudioDowload
{
    public class VkApiService : IVkApiService
    {
        readonly IAccessToken _accessToken;
        public VkApiService(IAccessToken accessToken) 
        {
           _accessToken = accessToken;
        }
        async Task<List<VkNet.Model.Attachments.Audio>> IVkApiService.GetAudiosAsync(int count)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();

            var api = new VkApi(services);
            Configs congigs = new Configs();
           
            var accessToken =  _accessToken.AccessToken();
            api.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });

            var audios = await api.Audio.GetAsync(new AudioGetParams
            {
                Count = count,
            });

            List<VkNet.Model.Attachments.Audio> audios1 = audios.ToList();
            
            return audios1;
       }
    }
}
