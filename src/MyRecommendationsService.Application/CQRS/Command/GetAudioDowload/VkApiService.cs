using Microsoft.Extensions.DependencyInjection;
using MyRecommendationsService.Application.Interface;
using VkNet.Model;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model.Attachments;

namespace MyRecommendationsService.Application.CQRS.Command.GetAudioDowload
{
    public class VkApiServiceMyRecom : IVkApiServiceMyRecom
    {

        Task<List<VkNet.Model.Attachments.Audio>> IVkApiServiceMyRecom.GetAudiosAsync(decimal count, decimal UserId)
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

            var audios = api.Audio.GetRecommendations(decimal count, decimal UserId);

            List<VkNet.Model.Attachments.Audio> audios1 = audios.ToList();

            return audios1;
        }
    }
}
