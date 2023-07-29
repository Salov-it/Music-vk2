

namespace Myaudio.Application.CQRS.Interface
{
    public interface IVkApiService
    {
      Task<List<VkNet.Model.Attachments.Audio>> GetAudiosAsync(int count);
    }
}
