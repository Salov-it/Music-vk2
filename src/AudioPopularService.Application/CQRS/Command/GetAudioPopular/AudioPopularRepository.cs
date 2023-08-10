using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class AudioPopularRepository : IAudioPopulaRepository
    {
        private readonly IAudioPopularContext _audioPopularContext;

        CancellationToken cancellationToken = new CancellationToken();

        public AudioPopularRepository(IAudioPopularContext audioPopularContext)
        {
            _audioPopularContext = audioPopularContext;
        }
        public async Task AddAsync(AudioPopul audio)
        {
            await _audioPopularContext.audiopopul.AddRangeAsync(audio);
        }

        public async Task<List<AudioPopul>> GetAllAsync()
        {
          return  await _audioPopularContext.audiopopul.ToListAsync();
        }

        public void Remove(AudioPopul audio)
        {
            _audioPopularContext.audiopopul.Remove(audio);
        }

        public async Task SaveChangesAsync()
        {
            await _audioPopularContext.SaveChangesAsync(cancellationToken);
        }
    }
}
