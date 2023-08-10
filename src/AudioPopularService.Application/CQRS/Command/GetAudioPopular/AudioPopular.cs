using AudioPopularService.Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class AudioPopular : IAudioPopular
    {
        
       async Task<List<VkNet.Model.Attachments.Audio>> IAudioPopular.AudioPopular(uint Count, string accessToken)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);

            api.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });

            var audios = await api.Audio.GetPopularAsync(count: Count);
            return  audios.ToList();
        }
    }
}
