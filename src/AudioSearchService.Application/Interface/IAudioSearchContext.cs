using AudioSearchService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioSearchService.Application.Interface
{
    public interface IAudioSearchContext
    {
        public DbSet<AudioSearc>audios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
