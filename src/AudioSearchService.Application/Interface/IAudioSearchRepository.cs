using AudioSearchService.Domain;

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
