using AudioSearchService.Domain;

namespace AudioSearchService.Application.Interface
{
    public interface IAudioSearch
    {
        public Task<List<VkNet.Model.Attachments.Audio>> audioSearch(string Search,int Count, string accessToken);
    }
}
