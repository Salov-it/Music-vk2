using Microsoft.EntityFrameworkCore;
using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Interface
{
    public interface IContext
    {
        public DbSet<Myaudios> Myaudio { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
