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
       
        async Task<List<VkNet.Model.Attachments.Audio>> IVkApiService.GetAudiosAsync(int count)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();

            var api = new VkApi(services);
            Configs congigs = new Configs();


            api.Authorize(new ApiAuthParams
            {
                AccessToken = "1"
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
