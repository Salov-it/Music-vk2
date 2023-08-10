

namespace AudioPopularService.Application.Interface
{
    public interface  IAudioPopular
    {
        public Task<List<VkNet.Model.Attachments.Audio>> AudioPopular(uint Count, string accessToken);
    }  
}

