namespace Myaudio.Application.Interface
{
    public interface IVkApiService
    {
        Task<List<VkNet.Model.Attachments.Audio>> GetAudiosAsync(int count);
    }
}
