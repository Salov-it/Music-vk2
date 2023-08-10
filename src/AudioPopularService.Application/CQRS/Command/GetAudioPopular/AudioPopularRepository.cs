using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class AudioPopularRepository : IAudioPopulaRepository
    {
        public Task AddAsync(AudioPopul audio)
        {
            throw new NotImplementedException();
        }

        public Task<List<AudioPopul>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(AudioPopul audio)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
