

namespace MyRecommendationsService.Application.Interface
{
    public interface IVkApiServiceMyRecom
    {
        Task<List<VkNet.Model.Attachments.Audio>> GetAudiosAsync(decimal count, decimal UserId);
    }
}
