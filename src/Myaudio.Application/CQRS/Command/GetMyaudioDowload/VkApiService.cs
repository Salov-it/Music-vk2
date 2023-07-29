using Microsoft.Extensions.DependencyInjection;
using Myaudio.Application.CQRS.Interface;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet;
using VkNet.AudioBypassService.Extensions;

namespace Myaudio.Application.CQRS.Command.GetMyaudioDowload
{
    public class VkApiService : IVkApiService
    {
       

        async Task<List<VkNet.Model.Attachments.Audio>> IVkApiService.GetAudiosAsync(int count)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();

            var api = new VkApi(services);

            api.Authorize(new ApiAuthParams // в дальнейшем переделать на авторизацию по токену
            {
                ApplicationId = 7822351,
                Login = "89244452428",
                Password = "Salov1999"
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
