using AudioSearchService.Application.Interface;
using AudioSearchService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioSearchService.Application.CQRS.Command.PostAudioSearch
{
    public class AuduioSearchRepository : IAudioSearchRepository
    {
        readonly IAudioSearchContext _audioSearchContext;
        CancellationToken cancellationToken = new CancellationToken();
        public AuduioSearchRepository(IAudioSearchContext audioSearchContext)
        {
            _audioSearchContext = audioSearchContext;
        }

        public async Task AddAsync(AudioSearc audio)
        {
            await _audioSearchContext.audios.AddAsync(audio);
        }

        public async Task<List<AudioSearc>> GetAllAsync()
        {
            return await _audioSearchContext.audios.ToListAsync();
        }

        public void Remove(AudioSearc audio)
        {
            _audioSearchContext.audios.Remove(audio);
        }

        public async Task SaveChangesAsync()
        {
            await _audioSearchContext.SaveChangesAsync(cancellationToken);
        }
    }
}
