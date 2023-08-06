using AudioSearchService.Domain;
using Myaudio.Application.CQRS.Interface;
using Myaudio.Domain;

namespace AudioSearchService.Application.Interface
{
    public interface IAudioSearchRepository
    {
        Task<List<AudioSearc>> GetAllAsync();
        Task AddAsync(AudioSearc audio);
        void Remove(AudioSearc audio);
        Task SaveChangesAsync();
    }
}
