using AudioSearchService.Application.Interface;
using AudioSearchService.Domain;
using Microsoft.Extensions.DependencyInjection;
using Myaudio.Domain;
using UserService.Application.Interface;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace AudioSearchService.Application.CQRS.Command
{
    public class AudioSearch : IAudioSearch
    {
        public List<VkNet.Model.Attachments.Audio> Audios { get; set; }
        public async Task<List<VkNet.Model.Attachments.Audio>> audioSearch(string Search, int Count, string accessToken)
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
