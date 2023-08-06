using AudioSearchService.Application.Interface;
using AudioSearchService.Domain;
using Microsoft.EntityFrameworkCore;
using Myaudio.Application.CQRS.Interface;
using Myaudio.Domain;
using UserService.Application.Interface;
using VkNet.Model;

namespace Persistance.Base
{
    public class Context : DbContext, IContext, IUserContext, IAudioSearchContext
    {
        public DbSet<Myaudios> Myaudio { get; set; }
        public DbSet<UserService.Domain.User> user { get; set; }
        public DbSet<AudioSearc> audios { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Config());
            base.OnModelCreating(modelBuilder);
        }
    }
}
