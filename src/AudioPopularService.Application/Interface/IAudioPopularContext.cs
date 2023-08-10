using AudioPopularService.Domain;
using Microsoft.EntityFrameworkCore;

namespace AudioPopularService.Application.Interface
{
    public interface IAudioPopularContext
    {
        public DbSet<AudioPopul> audiopopul { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
