using AudioSearchService.Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace AudioSearchService.Application.CQRS.Command.GetAudioSearch
{
    public class AudioSearch : IAudioSearch
    {
        public List<Audio> Audios { get; set; }
        public async Task<List<Audio>> audioSearch(string Search, int Count, string accessToken)
        {

            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);

            api.Authorize(new ApiAuthParams
            {
                AccessToken = accessToken
            });

            var audios = await api.Audio.SearchAsync(new AudioSearchParams
            {
                Query = Search,
                Count = Count
            });
            return Audios = audios.ToList();
        }
    }
}
