using Microsoft.EntityFrameworkCore;
using Myaudio.Domain;

namespace Myaudio.Application.Interface
{
    public interface IMyaudioContext 
    {
        public DbSet<Myaudios> myaudios {  get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
