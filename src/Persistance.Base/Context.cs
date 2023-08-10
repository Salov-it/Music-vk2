using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;
using AudioSearchService.Application.Interface;
using AudioSearchService.Domain;
using Microsoft.EntityFrameworkCore;
using Myaudio.Application.CQRS.Interface;
using Myaudio.Domain;
using UserService.Application.Interface;

namespace Persistance.Base
{
    public class Context : DbContext, IContext, IUserContext, IAudioSearchContext, IAudioPopularContext
    {
        public DbSet<Myaudios> Myaudio { get; set; }
        public DbSet<UserService.Domain.User> user { get; set; }
        public DbSet<AudioSearc> audios { get; set; }
        public DbSet<AudioPopul> audiopopul { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Config());
            base.OnModelCreating(modelBuilder);
        }
    }
}
