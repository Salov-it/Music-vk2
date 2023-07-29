using MyRecommendationsService.Domain;

namespace MyRecommendationsService.Application.Interface
{
    public interface IAudiosRepository
    {
        Task<List<Audio>> GetAllAsync();
        Task AddAsync(Audio myaudio);
        void Remove(Audio myaudio);
        Task SaveChangesAsync();
    }
}
