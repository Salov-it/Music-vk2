using Microsoft.EntityFrameworkCore;
using VkNet.Model;

namespace UserService.Application.Interface
{
    public interface IUserContext
    {
        public DbSet<Domain.User> user { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
