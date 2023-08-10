using AudioPopularService.Domain;

namespace AudioPopularService.Application.Interface
{
    public interface IAudioPopulaRepository
    {
        Task<List<AudioPopul>> GetAllAsync();
        Task AddAsync(AudioPopul audio);
        void Remove(AudioPopul audio);
        Task SaveChangesAsync();
    }
}
