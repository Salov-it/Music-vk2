using Microsoft.EntityFrameworkCore;
using MyRecommendationsService.Domain;

namespace MyRecommendationsService.Application.Interface
{
    public interface IContextMyRecom
    {
        public DbSet<Audio> Audios { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
